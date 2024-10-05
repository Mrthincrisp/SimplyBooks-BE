﻿namespace SimplyBooks.DTOs
{
    public class BookEditDTO
    {
        public int AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public bool Sale { get; set; }
    }
}
