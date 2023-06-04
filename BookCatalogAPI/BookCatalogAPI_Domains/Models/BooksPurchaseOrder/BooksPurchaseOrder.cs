using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.BooksPurchaseOrder
{
    public class BooksPurchaseOrder : AbstractDomain
    {
        public long BookId { get; set; }
        public long PurchaseOrderId { get; set; }

        public BooksPurchaseOrder(long bookId, long purchaseOrderId)
        {
            BookId = bookId;
            PurchaseOrderId = purchaseOrderId;
        }
    }
}
