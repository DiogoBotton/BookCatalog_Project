using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models
{
    public class ReturnBaseClass
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
