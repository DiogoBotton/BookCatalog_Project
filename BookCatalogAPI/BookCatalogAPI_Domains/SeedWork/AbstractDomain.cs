using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains
{
    public abstract class AbstractDomain
    {
        public virtual long Id { get; protected set; }
    }
}
