using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.User
{
    public class User : AbstractDomain
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long TypeUserId { get; set; }

        public User(string name, string email, string password, long typeUserId)
        {
            Name = name;
            Email = email;
            Password = password;
            TypeUserId = typeUserId;
            IsActive = true;
        }
    }
}
