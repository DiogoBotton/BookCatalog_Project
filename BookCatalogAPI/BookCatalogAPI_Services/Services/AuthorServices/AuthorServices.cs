using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Services.Services.AuthorServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.AuthorServices
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorServices(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorReturn> GetAll()
        {
            try
            {
                var result = await _authorRepository.GetAllAsync();

                return new AuthorReturn { Status = true, Authors = result };
            }
            catch (Exception)
            {
                return new AuthorReturn { 
                    Status = true, 
                    Message = "Houve algum erro ao retornas todos os autores.", 
                    Date = DateTime.Now
                };
            }
        }
    }
}
