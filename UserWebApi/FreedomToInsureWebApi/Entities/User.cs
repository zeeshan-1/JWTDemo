using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreedomToInsureWebApi.Entities
{
    public class User : IEntity 
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }
        [JsonIgnore]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        #endregion
    }
}
