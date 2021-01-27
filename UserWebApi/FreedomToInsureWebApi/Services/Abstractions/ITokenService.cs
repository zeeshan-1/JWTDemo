using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;

namespace FreedomToInsureWebApi.Services.Abstractions
{
    /// <summary>
    /// Token service abstraction/interface to support
    /// SOLID (I = interface segregation principle) and
    /// SOLID (D = dependency inversion principle).
    /// </summary>
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
