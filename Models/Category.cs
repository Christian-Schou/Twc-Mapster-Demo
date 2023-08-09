using System.ComponentModel.DataAnnotations;

namespace TwcMapster.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
