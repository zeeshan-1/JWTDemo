using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreedomToInsureWebApi.Entities
{
    /// <summary>
    /// Root interface for all entities in the
    /// system. It can be enhanced further in future.
    /// NOTE:- I like to start with Root interface fo all the aggregate entities
    /// because it supports DDD and clean architecture principles.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
