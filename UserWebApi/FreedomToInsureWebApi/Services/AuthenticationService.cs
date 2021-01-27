using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Configurations;
using FreedomToInsureWebApi.Entities;
using FreedomToInsureWebApi.Models;
using FreedomToInsureWebApi.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace FreedomToInsureWebApi.Services
{
    /// <summary>
    /// Authentication class to handle the authentication of the user.
    /// This is implemented separately to support SOLID (S.R.P principle) and with the
    /// future intent in mind to handle authentication in any customized way
    /// that could be different from the normal user data service which
    /// handles other CRUD features of user. 
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private DataContext _dataContext;
        private ITokenService _tokenService;
        private IUserDataService _userService;
        #endregion

        #region Constructor
        public AuthenticationService(ITokenService tokenService , 
            IUserDataService userService)
        {
            this._tokenService = tokenService;
            this._userService = userService;
        }
        #endregion
        #region Member functions & Methods
        public User Authenticate(string userName, string password)
        {

            User foundAuthenticatedUser = null;
            foundAuthenticatedUser = this._userService.GetAll().ToList().SingleOrDefault(user =>
                user.Username.ToLowerInvariant().Equals(userName.ToLowerInvariant()) &&
                user.Password.ToLowerInvariant().Equals(password.ToLowerInvariant()));

            return foundAuthenticatedUser;
        }
        #endregion
    }
}
