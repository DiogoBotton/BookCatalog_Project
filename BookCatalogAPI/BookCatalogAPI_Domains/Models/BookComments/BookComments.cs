using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.BookComments
{
    public class BookComments : AbstractDomain
    {
        public string Comments { get; set; }
        public long BookId { get; set; }
        public bool IsActive { get; set; }

        public BookComments(string comments, long bookId)
        {
            Comments = comments;
            BookId = bookId;
            IsActive = true;
        }

        public void DeleteComment() => IsActive = false;
    }
}
