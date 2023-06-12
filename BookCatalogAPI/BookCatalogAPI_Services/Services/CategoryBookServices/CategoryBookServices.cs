using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.CategoryBook;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Services.Services.CategoryBookServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.CategoryBookServices
{
    public class CategoryBookServices : ICategoryBookServices
    {
        private readonly ICategoryBookRepository _categoryBookRepository;

        public CategoryBookServices(ICategoryBookRepository categoryBookRepository)
        {
            _categoryBookRepository = categoryBookRepository;
        }

        public async Task<CategoryBookReturn> GetAll()
        {
            try
            {
                var result = await _categoryBookRepository.GetAllAsync();

                return new CategoryBookReturn { Status = true, CategoryBooks = result };
            }
            catch (Exception)
            {
                return new CategoryBookReturn
                {
                    Status = true,
                    Message = "Houve algum erro ao retornas todos os autores.",
                    Date = DateTime.Now
                };
            }
        }
    }
}
