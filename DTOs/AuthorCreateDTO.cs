namespace SimplyBooks.DTOs
{
    public class AuthorCreateDTO
    {
        public string? Email { get; set; }
        public bool Favorite { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }

    }
}
