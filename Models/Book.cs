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

        public Book()
        {
        }

        // Constructor for the book
        public Book(string title, string author, int releaseYear, string publisher, double price, int categoryId)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Publisher = publisher;
            Price = price;
        }

        // Accessor methods for the book
        public string GetTitle()
        {
            return Title;
        }

        public string GetAuthor()
        {
            return Author;
        }
        public int GetReleaseYear()
        {
            return ReleaseYear;
        }
        public string GetPublisher()
        {
            return Publisher;
        }
        public double GetCost()
        {
            return Price;
        }

        // Mutator methods for the book
        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }
        public void SetReleaseYear(int releaseYear)
        {
            ReleaseYear = releaseYear;
        }
        public void SetPublisher(string publisher)
        {
            Publisher = publisher;
        }
        public void SetPrice(double price)
        {
            Price = price;
        }

        // Method to print the book details
        public override string ToString()
        {
            return "The details of the book are: " + Title + ", " + Author + ", " + ReleaseYear + ", " + Publisher + ", " + Price;
        }
    }
}
