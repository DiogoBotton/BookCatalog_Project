using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Author
{
    public class Author : AbstractDomain
    {
        public string Name { get; set; }

        public Author(string name)
        {
            Name = name;
        }
    }
}
