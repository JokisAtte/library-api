using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace LibraryApi.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author);
        }
    }
}

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = "";
    [Required]
    public int Year { get; set; } = int.MinValue;
    [MinLength(1)]
    public string? Publisher { get; set; }
    public string? Description { get; set; }
    public int AuthorId { get; set; }
    [Required]
    public Author Author { get; set; } = new Author { };
}

public class Author
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = "";

}