using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;
using FreedomToInsureWebApi.Models;
using FreedomToInsureWebApi.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreedomToInsureWebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private IUserDataService _userService;
        private ITokenService _tokenService;
        private IAuthenticationService _authenticationService;
        #endregion

        #region Constructors
        public UsersController(IUserDataService userService ,
            ITokenService tokenService , IAuthenticationService authenticationService)
        {
            this._userService = userService;
            this._authenticationService = authenticationService;
            this._tokenService = tokenService;
        }
        #endregion

        #region Member Methods & Functions
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequest authReqModel)
        {
            AuthResponse authResponse = null;

            //if (authReqModel == null)
            //{
            //    return BadRequest(new { message = "No request parameters found." });
            //}

            //if(string.IsNullOrEmpty(authReqModel.UserName))
            //{
            //    return BadRequest(new { message = "User name is empty or incorrect." });
            //}

            //if (string.IsNullOrEmpty(authReqModel.Password))
            //{
            //    return BadRequest(new { message = "Password is empty or incorrect." });
            //}

            if (this.IsRequestValid(authReqModel,
                    out BadRequestObjectResult badRequestResult) == false)
            {
                return badRequestResult;
            }

            // Authenticating the user first....
            User foundAuthenticatedUser = this._authenticationService.Authenticate(authReqModel.UserName, authReqModel.Password);

            if (foundAuthenticatedUser == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            else
            {
                // Generating the Jwt token and adding it to the response ...
                if (this._tokenService != null)
                {
                    string generatedToken = this._tokenService.GenerateToken(foundAuthenticatedUser);

                    if (string.IsNullOrEmpty(generatedToken) == false)
                    {
                        authResponse = new AuthResponse(foundAuthenticatedUser, generatedToken);
                    }
                }
            }
            
            return Ok(authResponse);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = this._userService.GetAll();
            return Ok(users);
        }

        //[AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthRequest authReqModel)
        {
            AuthResponse response = null;
            if (this.IsRequestValid(authReqModel , 
                    out BadRequestObjectResult badRequestResult) == false)
            {
                return badRequestResult;
            }

            User registeredUser = this._userService.Register( new User() { Username = authReqModel.UserName , Password = authReqModel.Password});

            if (registeredUser != null)
            {
               response = new AuthResponse(registeredUser, string.Empty);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = this._userService.GetById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        private bool ValidateAuthRequest(AuthRequest authRequest)
        {
            bool result = true;
            if (authRequest != null)
            {
                if (string.IsNullOrEmpty(authRequest.UserName) ||
                    string.IsNullOrEmpty(authRequest.Password))
                {
                    result = false;
                }
            }
            return result;
        }

        private bool IsRequestValid(AuthRequest authRequest , out BadRequestObjectResult result)
        {
            bool isInValid = true;
            result = null;
            if (authRequest == null)
            {
                result = BadRequest(new { message = "No request parameters found." });
                return isInValid = false;
            }

            if (string.IsNullOrEmpty(authRequest.UserName))
            {
                result = BadRequest(new { message = "User name is empty or incorrect." });
                return isInValid = false;
            }

            if (string.IsNullOrEmpty(authRequest.Password))
            {
                result = BadRequest(new { message = "Password is empty or incorrect." });
                return isInValid = false;
            }

            return isInValid;
        }
        #endregion
    }
}
