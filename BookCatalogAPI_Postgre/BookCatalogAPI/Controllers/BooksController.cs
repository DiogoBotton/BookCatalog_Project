using BookCatalogAPI.Helpers.Utils;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Services.Services.BookServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBaseAPI
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] CreateBookInput input)
        {
            try
            {
                var result = await _bookServices.Create(input);

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpPut("alter/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CreateBookInput input)
        {
            try
            {
                var result = await _bookServices.Update(id, input);

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookServices.GetAll();

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                var result = _bookServices.GetById(id);

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpGet("lastReleases/{quantity}")]
        public async Task<IActionResult> GetLastReleases([FromRoute] int quantity)
        {
            try
            {
                var result = await _bookServices.GetLastReleases(quantity);

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }
    }
}
