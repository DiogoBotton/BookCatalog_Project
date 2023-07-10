using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogAPI_Domains.Models.Book.Interfaces;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookCatalogContext ctx) : base(ctx)
        {
        }

        public async Task<List<Book>> GetLastReleases(int quantity)
        {
            return await _ctx.Books.OrderByDescending(x => x.ReleaseDate).Take(quantity).ToListAsync();
        }
    }
}
