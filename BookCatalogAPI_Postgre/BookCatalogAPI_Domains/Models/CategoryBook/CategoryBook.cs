using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.CategoryBook
{
    public class CategoryBook : AbstractDomain
    {
        public string Description { get; set; }

        public CategoryBook(string description)
        {
            Description = description;
        }
    }
}
