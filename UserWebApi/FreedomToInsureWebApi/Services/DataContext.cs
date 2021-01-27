using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreedomToInsureWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreedomToInsureWebApi.Services
{
    /// <summary>
    /// Data context classes to provide the entity framwework context based repository functions
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@freedomitsupport.com",
                    Password ="admin",
                    Username = "admin"
                });
        }
    }
}
