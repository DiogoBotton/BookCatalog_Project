using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Author
{
    public class AuthorReturn : ReturnBaseClass
    {
        public List<Author> Authors { get; set; }
        public Author Author { get; set; }
    }
}
