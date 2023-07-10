using BookCatalogAPI_Domains.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.CategoryBook
{
    public class CategoryBookReturn : ReturnBaseClass
    {
        public CategoryBook CategoryBook { get; set; }
        public List<CategoryBook> CategoryBooks { get; set; }
    }
}
