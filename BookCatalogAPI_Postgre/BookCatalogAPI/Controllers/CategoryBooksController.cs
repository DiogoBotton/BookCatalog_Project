using BookCatalogAPI.Helpers.Utils;
using BookCatalogAPI_Services.Services.BookServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBooksController : ControllerBaseAPI
    {
        private readonly IBookServices _bookServices;

        public CategoryBooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookServices.CategoryBookGetAll();

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todas as categorias de livros.");
            }
        }
    }
}
