using BookCatalogAPI.Helpers.Utils;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Services.Services.AuthorServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBaseAPI
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _authorServices.GetAll();

                return VerifyResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os autores.");
            }
        }
    }
}
