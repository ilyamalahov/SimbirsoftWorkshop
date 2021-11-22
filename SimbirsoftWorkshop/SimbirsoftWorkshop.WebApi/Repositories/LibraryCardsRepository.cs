using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Data;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    public class LibraryCardsRepository : ILibraryCardsRepository
    {
        private readonly BookLibraryContext bookLibraryContext;

        public LibraryCardsRepository(BookLibraryContext bookLibraryContext)
        {
            this.bookLibraryContext = bookLibraryContext;
        }

        public async Task<LibraryCard> GetLibraryCardAsync(int personId, int bookId)
        {
            return await bookLibraryContext.LibraryCards.FindAsync(bookId, personId);
        }

        public async Task AddLibraryCardAsync(LibraryCard libraryCard)
        {
            await bookLibraryContext.LibraryCards.AddAsync(libraryCard);
            await bookLibraryContext.SaveChangesAsync();
        }

        public async Task DeleteLibraryCardAsync(LibraryCard libraryCard)
        {
            bookLibraryContext.LibraryCards.Remove(libraryCard);
            await bookLibraryContext.SaveChangesAsync();
        }
    }
}
