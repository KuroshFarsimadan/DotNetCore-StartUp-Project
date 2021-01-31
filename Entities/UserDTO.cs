using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Entities
{
    public class UserDTO : IdentityUser
    {
        // User ID is already inherited from IdentityUser object
        //public int Id { get; set; }
        // UserName is already inherited from IdentityUser object
        //public string UserName { get; set; }
        public string Sex { get; set; }
        public string DetailedProfile { get; set; }
        public string PreferredCompany { get; set; }
        public string Hobbies { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime LastActiveDate { get; set; } = DateTime.Now;
        public byte[] PasswordSalt { get; set; }
        // Password hash is already inherited from IdentityUser object, but we are overriding it for custom behavior
        public byte[] PasswordHash { get; set; } 
        public string Password { get; set; }
        public string Token { get; set; }
        public string Errors { get; set; }
    }
}
