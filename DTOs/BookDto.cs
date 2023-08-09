using TwcMapster.Models;

namespace TwcMapster.DTOs
{
    public class BookDto : BaseDto<BookDto, Book>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int ReleaseYear { get; set; }

        public string Publisher { get; set; }

        public string Price { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public override void AddCustomMappings()
        {
            // Mapster can map properties with different names
            // Here we split the price into two properties for the model behind the DTO
            SetCustomMappings()
                .Map(dest => dest.Price,
                     src => Convert.ToInt32(src.Price.Split(' ', StringSplitOptions.None)[0]))
                .Map(dest => dest.Currency,
                     src => src.Price.Split(' ', StringSplitOptions.None)[1]);

            // Mapping from model to DTO
            SetCustomMappingsReverse()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Author, src => src.Author)
                .Map(dest => dest.ReleaseYear, src => src.ReleaseYear)
                .Map(dest => dest.Publisher, src => src.Publisher)
                .Map(dest => dest.Price, src => $"{src.Price} {src.Currency}")
                .Map(dest => dest.CategoryName, src => src.Category.Name);
        }
    }
}
