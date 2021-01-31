using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
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
        public byte[] PasswordHash { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Errors { get; set; }
    }
}
