using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.DTOs
{
    public class AuthorEditDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Favorite is required.")]
        public bool Favorite { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public string? Image { get; set; }

    }
}
