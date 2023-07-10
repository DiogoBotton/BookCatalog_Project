using BookCatalogAPI_Domains.Models.PurchaseOrder;
using BookCatalogAPI_Domains.Models.PurchaseOrder.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
