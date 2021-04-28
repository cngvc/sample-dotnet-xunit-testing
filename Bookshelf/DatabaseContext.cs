using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
