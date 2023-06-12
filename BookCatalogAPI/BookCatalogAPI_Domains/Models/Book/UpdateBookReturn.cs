using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book
{
    public class UpdateBookReturn : ReturnBaseClass
    {
        public Book book { get; set; }
    }
}
