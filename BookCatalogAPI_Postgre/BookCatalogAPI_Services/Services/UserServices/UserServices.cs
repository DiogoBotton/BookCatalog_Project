using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Services.Services.UserServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly ICategoryBookRepository _categoryBookRepository;

        public UserServices(ICategoryBookRepository categoryBookRepository)
        {
            _categoryBookRepository = categoryBookRepository;
        }
    }
}
