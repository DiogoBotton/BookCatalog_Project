using System.ComponentModel.DataAnnotations;

namespace BookCatalogAPI.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public string ImageBase64 { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long AuthorId { get; set; }
        [Required]
        public long CategoryBookId { get; set; }
    }
}
