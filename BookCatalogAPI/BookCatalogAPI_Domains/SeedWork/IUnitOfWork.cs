using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains
{
    public interface IUnitOfWork
    {
        Task SaveDbChanges(CancellationToken cancellationToken = default(CancellationToken));
    }
}
