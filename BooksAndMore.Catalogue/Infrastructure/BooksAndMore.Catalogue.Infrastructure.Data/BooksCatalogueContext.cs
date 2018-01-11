using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System.Data.Entity;

namespace BooksAndMore.Catalogue.Infrastructure.Data
{
    public class BooksCatalogueContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BooksCatalogueContext(string nameOrConnectionString) :
            base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasMany(book => book.Authors).WithMany()
                .Map(configuration => configuration
                    .ToTable("BookAuthors")
                    .MapLeftKey("BookId")
                    .MapRightKey("AuthorId"));
        }
    }
}
