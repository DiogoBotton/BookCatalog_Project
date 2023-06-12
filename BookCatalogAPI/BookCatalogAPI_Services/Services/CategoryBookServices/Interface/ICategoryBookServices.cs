using BookCatalogAPI_Domains.Models.CategoryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.CategoryBookServices.Interface
{
    public interface ICategoryBookServices
    {
        Task<CategoryBookReturn> GetAll();
    }
}
