using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreedomToInsureWebApi.Models
{
    /// <summary>
    /// Marker interface to support DI and abstractions
    /// </summary>
    public interface IRequest
    {

    }

    /// <summary>
    /// Request class to provide simple request parameters
    /// for use in this micro web api application. Obviously
    /// this class can be tailored/enhanced as system grows with
    /// proper abstraction interfaces. 
    /// </summary>
    public class AuthRequest : IRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
