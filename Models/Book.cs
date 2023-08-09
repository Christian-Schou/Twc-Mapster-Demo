using System.ComponentModel.DataAnnotations;

namespace TwcMapster.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        public string Publisher { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Currency { get; set; } = "USD";

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Method to print the book details
        public override string ToString()
        {
            return "The details of the book are: " + Title + ", " + Author + ", " + ReleaseYear + ", " + Publisher + ", " + Price;
        }
    }
}
