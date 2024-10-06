using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.DTOs
{
    public class BookEditDTO
    {
        [Required(ErrorMessage = "AuthorId is required.")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Image URL is required.")]
        public string? Image { get; set; }
        public double Price { get; set; }
        [Required(ErrorMessage = "Sale status is required.")]
        public bool Sale { get; set; }
    }
}
