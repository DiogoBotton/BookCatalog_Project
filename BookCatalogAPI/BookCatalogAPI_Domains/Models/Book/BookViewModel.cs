using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.CategoryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string ImageBase64 { get; set; }
        public int Volume { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Author.Author? Author { get; set; }
        public CategoryBook.CategoryBook? CategoryBook { get; set; }
    }
}
