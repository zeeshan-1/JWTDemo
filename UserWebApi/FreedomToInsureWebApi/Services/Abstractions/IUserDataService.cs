using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;

namespace FreedomToInsureWebApi.Services.Abstractions
{
    /// <summary>
    /// User data service abstraction/interface to support
    /// SOLID (I = interface segregation principle) and
    /// SOLID (D = dependency inversion principle).
    /// </summary>
    public interface IUserDataService
    {
        User Register(User userToBeRegistered);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
