using BookCatalogAPI_Domains.Models.CategoryBook;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class CategoryBookRepository : BaseRepository<CategoryBook>, ICategoryBookRepository
    {
        public CategoryBookRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
