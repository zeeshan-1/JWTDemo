using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Configurations;
using FreedomToInsureWebApi.Entities;
using FreedomToInsureWebApi.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace FreedomToInsureWebApi.Services
{
    /// <summary>
    /// User service class to handle all the user db CRUD related functions
    /// </summary>
    public class UserService : IUserDataService
    {
        #region Fields
        private DataContext _dataContext;
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructors
        public UserService(
            DataContext context,
            IOptions<AppSettings> appSettings)
        {
            this._dataContext = context;
            this._appSettings = appSettings.Value;
        }
        #endregion

        #region Member functions & Methods
        public IEnumerable<User> GetAll()
        {
            return this._dataContext.Users;
        }

        public User GetById(int id)
        {
            return this._dataContext.Users.Find(id);
        }

        public User Register(User userToBeRegistered)
        {
            User registeredUser = null;
            if(userToBeRegistered != null)
            {
                this._dataContext.Add(userToBeRegistered);
                if (this._dataContext.SaveChanges() > 0)
                {
                    if (userToBeRegistered.Id > 0)
                    {
                        registeredUser = userToBeRegistered;
                    }
                };
            }

            return registeredUser;
        }
        #endregion
    }
}
