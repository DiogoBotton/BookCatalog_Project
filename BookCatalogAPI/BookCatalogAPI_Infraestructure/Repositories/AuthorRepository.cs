using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Infraestructure.Contexts;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}