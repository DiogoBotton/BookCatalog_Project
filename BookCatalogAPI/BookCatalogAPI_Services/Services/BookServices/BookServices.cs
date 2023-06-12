using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.Book.Interfaces;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Services.Services.BookServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Services.Services.BookServices
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryBookRepository _categoryBookRepository;

        public BookServices(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryBookRepository categoryBookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryBookRepository = categoryBookRepository;
        }

        public async Task<UpdateBookReturn> Create(CreateBookInput input)
        {
            try
            {
                Book newBook = new Book(input.Name, input.Synopsis, input.ImageBase64, input.Volume, input.Weight, input.Price, input.AuthorId, input.CategoryBookId);
                var bookDb = await _bookRepository.CreateAsync(newBook);

                await _bookRepository.UnitOfWork.SaveDbChanges();

                return new UpdateBookReturn { Status = true, Message = "Livro criado com sucesso", StatusCode = HttpStatusCode.OK, book = bookDb };
            }
            catch (Exception)
            {
                return new UpdateBookReturn
                {
                    Status = false,
                    Message = "Houve algum erro na criação do livro.",
                    Date = DateTime.Now,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<UpdateBookReturn> Update(long id, CreateBookInput input)
        {
            try
            {
                var bookDb = _bookRepository.GetById(id);

                if (bookDb == null)
                    return new UpdateBookReturn { Status = false, Message = "Este livro não existe.", StatusCode = HttpStatusCode.NotFound };

                bookDb.UpdateBook(input.Name, input.Synopsis, input.ImageBase64, input.Volume, input.Weight, input.Price, input.AuthorId, input.CategoryBookId);

                if (!await _bookRepository.UpdateAsync(bookDb))
                    return new UpdateBookReturn { Status = false, Message = "Ocorreu um erro ao atualizar o livro.", StatusCode = HttpStatusCode.BadRequest };

                await _bookRepository.UnitOfWork.SaveDbChanges();

                return new UpdateBookReturn { Status = true, Message = "Livro atualizado com sucesso." };
            }
            catch (Exception)
            {
                return new UpdateBookReturn
                {
                    Status = false,
                    Message = "Houve algum erro na criação do livro.",
                    Date = DateTime.Now,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<BookReturn> GetAll()
        {
            try
            {
                List<Book> allBooks = await _bookRepository.GetAllAsync();

                List<BookViewModel> result = allBooks.Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Synopsis = x.Synopsis,
                    Volume = x.Volume,
                    Weight = x.Weight,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price,
                    ImageBase64 = x.ImageBase64,
                    Author = _authorRepository.GetById(x.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(x.CategoryBookId)
                }).ToList();

                return new BookReturn { Status = true, books = result };
            }
            catch (Exception)
            {
                return new BookReturn
                {
                    Status = false,
                    Message = "Houve algum erro na criação do livro.",
                    Date = DateTime.Now,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public BookReturn GetById(long id)
        {
            try
            {
                Book? bookDb = _bookRepository.GetById(id);

                if (bookDb == null)
                    return new BookReturn { Status = false, Message = "Este livro não existe.", StatusCode = HttpStatusCode.NotFound };

                BookViewModel result = new BookViewModel
                {
                    Id = bookDb.Id,
                    Name = bookDb.Name,
                    Synopsis = bookDb.Synopsis,
                    Volume = bookDb.Volume,
                    Weight = bookDb.Weight,
                    ReleaseDate = bookDb.ReleaseDate,
                    Price = bookDb.Price,
                    ImageBase64 = bookDb.ImageBase64,
                    Author = _authorRepository.GetById(bookDb.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(bookDb.CategoryBookId)
                };

                return new BookReturn { Status = true, book = result };
            }
            catch (Exception)
            {
                return new BookReturn
                {
                    Status = false,
                    Message = "Houve algum erro na criação do livro.",
                    Date = DateTime.Now,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<BookReturn> GetLastReleases(int quantity)
        {
            try
            {
                List<Book> allBooks = await _bookRepository.GetLastReleases(quantity);

                List<BookViewModel> result = allBooks.Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Synopsis = x.Synopsis,
                    Volume = x.Volume,
                    Weight = x.Weight,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price,
                    ImageBase64 = x.ImageBase64,
                    Author = _authorRepository.GetById(x.AuthorId),
                    CategoryBook = _categoryBookRepository.GetById(x.CategoryBookId)
                }).ToList();

                return new BookReturn { Status = true, books = result };
            }
            catch (Exception)
            {
                return new BookReturn
                {
                    Status = false,
                    Message = "Houve algum erro na criação do livro.",
                    Date = DateTime.Now,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
