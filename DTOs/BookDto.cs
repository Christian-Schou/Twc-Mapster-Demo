namespace TwcMapster.DTOs
{
    /// <summary>
    /// Book DTO
    /// </summary>
    public class BookDto : BaseDto<BookDto, Book>
    {
        /// <summary>
        /// Book Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Book Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book Release Year
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Book Publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Book Price. This is made up by the custom mapping.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Add the custom mappings for the DTO.
        /// The AddMapster in Program.cs will look for this in order to add the mappings.
        /// </summary>
        public override void AddCustomMappings()
        {
            // Mapster can map properties with different names
            // Here we split the price into two properties for the model behind the DTO
            SetCustomMappings()
                .Map(dest => dest.Price,
                     src => Convert.ToDouble(src.Price.Split(' ', StringSplitOptions.None)[0]))
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
