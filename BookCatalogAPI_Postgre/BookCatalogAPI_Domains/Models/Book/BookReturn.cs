using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book
{
    public class BookReturn : ReturnBaseClass
    {
        public List<BookViewModel> books { get; set; }
        public BookViewModel book { get; set; }
    }
}
