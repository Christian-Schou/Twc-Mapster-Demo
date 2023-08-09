using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwcMapster.Data;

namespace TwcMapster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly AppDbContext _context;

        public BookController(ILogger<BookController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            Book book = bookDto.Adapt<Book>();

            _logger.LogInformation($"Adding new book. {book}");

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int bookId)
        {
            BookDto bookDto = await _context.Books
                .Where(b => b.Id == bookId)
                .ProjectToType<BookDto>()
                .FirstOrDefaultAsync();

            if (bookDto is null)
            {
                return NotFound("The book was not found");
            }

            return Ok(bookDto);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var bookResult = await _context.Books
                .ProjectToType<BookDto>()
                .ToListAsync();

            if (bookResult.Count() == 0)
            {
                return NotFound("No books in database");
            }

            return Ok(bookResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDto bookDto, int bookId)
        {
            // Get the book in the database
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book is null)
            {
                return NotFound("The book was not found");
            }

            // Map the DTO onto the book we got from the database
            // This will update the book with the values from the DTO
            bookDto.ToModel(book);

            // Save the changes in the database
            await _context.SaveChangesAsync();

            return Ok(book);
        }
    }
}