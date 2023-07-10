using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.CategoryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.BookServices.Interface
{
    public interface IBookServices
    {
        Task<UpdateBookReturn> Create(CreateBookInput input);
        Task<UpdateBookReturn> Update(long id, CreateBookInput input);
        Task<BookReturn> GetAll();
        BookReturn GetById(long id);
        Task<BookReturn> GetLastReleases(int quantity);
        Task<CategoryBookReturn> CategoryBookGetAll();
    }
}
