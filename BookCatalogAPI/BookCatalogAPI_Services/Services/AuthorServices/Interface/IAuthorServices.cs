using BookCatalogAPI_Domains.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.AuthorServices.Interface
{
    public interface IAuthorServices
    {
        Task<AuthorReturn> GetAll();
    }
}
