using BookCatalogAPI_Domains.Models.Author.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _authorRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os autores.");
            }
        }
    }
}
