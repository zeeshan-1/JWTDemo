using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Configurations;
using FreedomToInsureWebApi.Entities;
using FreedomToInsureWebApi.Services.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FreedomToInsureWebApi.Services
{
    /// <summary>
    /// JWT token service class to provide generated JWT token
    /// </summary>
    public class JwtTokenService : ITokenService
    {
        #region Fields
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }
        #endregion

        #region Member functions & Methods
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
