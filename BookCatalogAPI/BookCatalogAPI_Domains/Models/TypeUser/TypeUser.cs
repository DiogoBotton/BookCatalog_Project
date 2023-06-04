using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.TypeUser
{
    public class TypeUser : AbstractDomain
    {
        public string Description { get; set; }

        public TypeUser(string description)
        {
            Description = description;
        }
    }
}
