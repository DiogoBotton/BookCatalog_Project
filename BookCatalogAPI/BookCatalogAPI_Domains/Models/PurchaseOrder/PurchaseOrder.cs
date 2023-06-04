using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.PurchaseOrder
{
    public class PurchaseOrder : AbstractDomain
    {
        public string ShippingZipCode { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }

        public PurchaseOrder(string shippingZipCode, string address, long userId)
        {
            ShippingZipCode = shippingZipCode;
            Address = address;
            UserId = userId;
        }
    }
}
