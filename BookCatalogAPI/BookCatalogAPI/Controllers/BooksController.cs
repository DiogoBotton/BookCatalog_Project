using BookCatalogAPI.ViewModels;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.Book.Interfaces;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryBookRepository _categoryBookRepository;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryBookRepository categoryBookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryBookRepository = categoryBookRepository;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] BookViewModel input)
        {
            try
            {
                Book newBook = new Book(input.Name, input.Synopsis, input.ImageBase64, input.Volume, input.Weight, input.Price, input.AuthorId, input.CategoryBookId);

                var bookDb = await _bookRepository.CreateAsync(newBook);

                await _bookRepository.UnitOfWork.SaveDbChanges();

                return Ok(bookDb);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpPut("alter/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] BookViewModel input)
        {
            try
            {
                var bookDb = _bookRepository.GetById(id);

                if(bookDb == null)
                    return StatusCode(404, "Este livro não existe.");

                bookDb.UpdateBook(input.Name, input.Synopsis, input.ImageBase64, input.Volume, input.Weight, input.Price, input.AuthorId, input.CategoryBookId);
                
                if(!await _bookRepository.UpdateAsync(bookDb))
                    return StatusCode(400, "Ocorreu um erro ao atualizar o livro.");

                await _bookRepository.UnitOfWork.SaveDbChanges();

                return Ok(bookDb);
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
                List<Book> allBooks = await _bookRepository.GetAllAsync();

                var result = allBooks.Select(x => new {
                    x.Id,
                    x.Name,
                    x.Synopsis,
                    x.Volume,
                    x.Weight,
                    x.ReleaseDate,
                    x.Price,
                    x.ImageBase64,
                    Author = _authorRepository.GetById(x.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(x.CategoryBookId)
                });

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLastReleases([FromRoute] long id)
        {
            try
            {
                Book? bookDb = _bookRepository.GetById(id);

                if(bookDb == null)
                    return StatusCode(404, "Este livro não existe.");

                var result = new
                {
                    bookDb.Id,
                    bookDb.Name,
                    bookDb.Synopsis,
                    bookDb.Volume,
                    bookDb.Weight,
                    bookDb.ReleaseDate,
                    bookDb.Price,
                    bookDb.ImageBase64,
                    Author = _authorRepository.GetById(bookDb.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(bookDb.CategoryBookId)
                };

                return Ok(result);
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
                List<Book> allBooks = await _bookRepository.GetLastReleases(quantity);

                var result = allBooks.Select(x => new {
                    x.Id,
                    x.Name,
                    x.Synopsis,
                    x.Volume,
                    x.Weight,
                    x.ReleaseDate,
                    x.Price,
                    x.ImageBase64,
                    Author = _authorRepository.GetById(x.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(x.CategoryBookId)
                });

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao resgatar todos os livros.");
            }
        }
    }
}
