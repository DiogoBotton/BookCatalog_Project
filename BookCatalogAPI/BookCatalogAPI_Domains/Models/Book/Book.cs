using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Domains.Models.Book
{
    public class Book : AbstractDomain
    {
        public string Synopsis { get; set; }
        public int Volume { get; set; }
        public double Weight { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long AuthorId { get; set; }
        public long CategoryBookId { get; set; }

        public Book(string synopsis, int volume, double weight, long authorId, long categoryBookId)
        {
            Synopsis = synopsis;
            Volume = volume;
            Weight = weight;
            AuthorId = authorId;
            CategoryBookId = categoryBookId;
            ReleaseDate = DateTime.Now;
        }

        public void UpdateBook(string synopsis, int volume, double weight, long authorId, long categoryBookId)
        {
            Synopsis = synopsis;
            Volume = volume;
            Weight = weight;
            AuthorId = authorId;
            CategoryBookId = categoryBookId;
        }
    }
}
