using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book
{
    public class Book : AbstractDomain
    {
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string ImageBase64 { get; set; }
        public int Volume { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long AuthorId { get; set; }
        public long CategoryBookId { get; set; }

        public Book(string name, string synopsis, string imageBase64, int volume, double weight, double price, long authorId, long categoryBookId)
        {
            Name = name;
            Synopsis = synopsis;
            ImageBase64 = imageBase64;
            Volume = volume;
            Weight = weight;
            Price = price;
            AuthorId = authorId;
            CategoryBookId = categoryBookId;
            ReleaseDate = ReleaseDate = DateTime.Now;

        }

        public void UpdateBook(string name, string synopsis, string imageBase64, int volume, double weight, double price, long authorId, long categoryBookId)
        {
            Name = name;
            Synopsis = synopsis;
            ImageBase64 = imageBase64;
            Volume = volume;
            Weight = weight;
            Price = price;
            AuthorId = authorId;
            CategoryBookId = categoryBookId;
        }
    }
}
