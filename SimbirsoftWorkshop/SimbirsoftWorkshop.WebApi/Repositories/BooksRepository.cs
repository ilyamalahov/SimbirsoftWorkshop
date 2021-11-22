using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirsoftWorkshop.WebApi.Data;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с книгами
    /// </summary>
    public sealed class BooksRepository : IBooksRepository
    {
        private readonly BookLibraryContext bookLibraryContext;

        public BooksRepository(BookLibraryContext bookLibraryContext)
        {
            this.bookLibraryContext = bookLibraryContext;
        }

        public async Task<IEnumerable<Book>> GetBooksByPersonIdAsync(int personId)
        {
            var books = from book in bookLibraryContext.Books
                            .Include(b => b.Author)
                            .Include(b => b.Genres)
                        join libraryCard in bookLibraryContext.LibraryCards on book.Id equals libraryCard.BookId
                        join person in bookLibraryContext.People on libraryCard.PersonId equals person.Id
                        where person.Id == personId
                        select book;

            return await books.ToListAsync();
        }
    }
}
