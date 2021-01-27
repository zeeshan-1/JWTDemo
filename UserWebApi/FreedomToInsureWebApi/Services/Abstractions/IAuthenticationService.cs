using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;
using FreedomToInsureWebApi.Models;

namespace FreedomToInsureWebApi.Services.Abstractions
{
    /// <summary>
    /// Authentication service abstraction/interface to support
    /// SOLID (I = interface segregation principle) and
    /// SOLID (D = dependency inversion principle). This class
    /// return the authenticated use details from database
    /// </summary>
    public interface IAuthenticationService
    {
        public User Authenticate(string userName, string password);
    }
}
