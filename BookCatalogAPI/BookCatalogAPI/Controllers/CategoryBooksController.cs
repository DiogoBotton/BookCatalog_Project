using BookCatalogAPI.Helpers.Utils;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Services.Services.CategoryBookServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBooksController : ControllerBaseAPI
    {
        private readonly ICategoryBookServices _categoryServices;

        public CategoryBooksController(ICategoryBookServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoryServices.GetAll();

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todas as categorias de livros.");
            }
        }
    }
}
