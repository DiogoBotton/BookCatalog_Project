using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBooksController : ControllerBase
    {
        private readonly ICategoryBookRepository _categoryBookRepository;

        public CategoryBooksController(ICategoryBookRepository categoryBookRepository)
        {
            _categoryBookRepository = categoryBookRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _categoryBookRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todas as categorias de livros.");
            }
        }
    }
}
