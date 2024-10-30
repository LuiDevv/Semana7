﻿namespace BookManagementAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int PublishedYear { get; set; }

        public bool IsValid()
        {
            return PublishedYear > 0 &&
                   !string.IsNullOrWhiteSpace(Title) &&
                   !string.IsNullOrWhiteSpace(Author) &&
                   !string.IsNullOrWhiteSpace(Genre);
        }
    }
}