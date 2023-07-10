using BookCatalogAPI_Domains;
using BookCatalogAPI_Domains.Models.BooksPurchaseOrder;
using BookCatalogAPI_Domains.Models.BooksPurchaseOrder.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class BooksPurchaseOrderRepository : BaseRepository<BooksPurchaseOrder>, IBooksPurchaseOrderRepository
    {
        public BooksPurchaseOrderRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
