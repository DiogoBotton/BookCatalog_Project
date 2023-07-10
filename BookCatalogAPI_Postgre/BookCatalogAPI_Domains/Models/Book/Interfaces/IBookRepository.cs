using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetLastReleases(int quantity);
    }
}
