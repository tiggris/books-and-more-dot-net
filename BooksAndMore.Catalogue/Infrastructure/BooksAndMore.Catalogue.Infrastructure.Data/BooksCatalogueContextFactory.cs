using System.Data.Entity.Infrastructure;

namespace BooksAndMore.Catalogue.Infrastructure.Data
{
    public class BooksCatalogueContextFactory : IDbContextFactory<BooksCatalogueContext>
    {
        public BooksCatalogueContext Create()
        {
            return new BooksCatalogueContext("BooksCatalogueDb");
        }
    }
}