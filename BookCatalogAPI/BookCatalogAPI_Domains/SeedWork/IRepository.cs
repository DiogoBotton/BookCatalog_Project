using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains
{
    public interface IRepository<T> where T : AbstractDomain
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> CreateAsync(T objeto);
        Task<bool> UpdateAsync(T objeto);
        Task<List<T>> GetAllAsync();
        T? GetById(long id);
    }
}
