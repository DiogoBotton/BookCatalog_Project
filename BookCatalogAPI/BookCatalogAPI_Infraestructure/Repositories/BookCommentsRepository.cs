using BookCatalogAPI_Domains.Models.BookComments;
using BookCatalogAPI_Domains.Models.BookComments.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class BookCommentsRepository : BaseRepository<BookComments>, IBookCommentsRepository
    {
        public BookCommentsRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
