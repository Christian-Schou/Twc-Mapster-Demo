using Microsoft.EntityFrameworkCore;

namespace TwcMapster.Data
{
    /// <summary>
    /// Application Database Context holding tables.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Books Table
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Categories Table
        /// </summary>
        public DbSet<Category> Categories { get; set; }
    }
}
