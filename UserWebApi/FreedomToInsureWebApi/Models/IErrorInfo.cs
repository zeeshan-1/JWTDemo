using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreedomToInsureWebApi.Models
{
    /// <summary>
    /// Interface to provide custom error implementations
    /// for models
    /// </summary>
    public interface IErrorInfo
    {
        bool HasError { get; set; }
        List<string> ErrorMessages { get; set; }
    }
}
