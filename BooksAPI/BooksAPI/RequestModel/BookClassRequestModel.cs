using System.ComponentModel.DataAnnotations;

namespace BooksAPI.RequestModel
{
    public class BookClassRequestModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? AuthorName { get; set; }
    }
}
