using Microsoft.EntityFrameworkCore;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;

namespace Quiz2_MohamedZakariaMohyEldin_.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksAuthors>().HasOne(x => x.books).WithMany(x => x.BooksAuthors).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BooksAuthors>().HasOne(x => x.authors).WithMany(x => x.BooksAuthors).HasForeignKey(x => x.AuthorsId);
            modelBuilder.Entity<BooksAuthors>().HasKey(x => new { x.AuthorsId, x.BookId});

            modelBuilder.Entity<BooksGenre>().HasOne(x => x.books).WithMany(x => x.BooksGenre).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BooksGenre>().HasOne(x => x.genre).WithMany(x => x.BooksGenre).HasForeignKey(x => x.GenreId);
            modelBuilder.Entity<BooksGenre>().HasKey(x => new { x.GenreId, x.BookId });
        }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<BooksGenre> BooksGenres { get; set; }
    }
}
