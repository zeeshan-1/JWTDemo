using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;

namespace FreedomToInsureWebApi.Models
{
    /// <summary>
    /// Marker interface to support DI and abstractions
    /// </summary>
    public interface IResponse
    {

    }

    /// <summary>
    /// Response class to support the returned parameters from the web api. 
    /// </summary>
    public class AuthResponse : IErrorInfo
    {
        #region Fields
        private List<string> errorMessages = new List<string>();
        #endregion

        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }

        public bool HasError { get; set; }

        public List<string> ErrorMessages
        {
            get { return this.errorMessages; }
            set { this.errorMessages = value; }

        }
        #endregion

        #region Constructors
        public AuthResponse() { }
        public AuthResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Email = user.Email;
            JwtToken = token;
        }
        #endregion
    }
}
