using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Sorting;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с книгами в памяти
    /// </summary>
    public sealed class BooksRepository : IBooksRepository
    {
        private const int identifierInitialValue = 1;
        private const int identifierIncrementStep = 1;

        /// <summary>
        /// 1.2.3 - Статичный список книг
        /// </summary>
        private readonly IList<BookDto> booksList;

        /// <summary>
        /// Создает новый объект репозитория
        /// </summary>
        public BooksRepository()
        {
            booksList = GetInitBooks();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<BookDto>> GetAllBooksAsync(GetAllBooksModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var allBooks = SortingHelper.SortBooks(booksList, model.Sortings);

            return Task.FromResult(allBooks);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<BookDto>> GetBooksByAuthorId(int authorId)
        {
            var booksByAuthorId = booksList.Where(b => b.AuthorId == authorId);

            return Task.FromResult(booksByAuthorId);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<int>> GetBookAuthorsIdsAsync()
        {
            var booksAuthorsIds = booksList.Select(b => b.AuthorId).Distinct();

            return Task.FromResult(booksAuthorsIds);
        }

        /// <inheritdoc/>
        public Task<bool> AddBookAsync(BookDto book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (BookExistsByTitleAndAuthor(book.Title, book.Author))
            {
                return Task.FromResult(false);
            }

            book.Id = GenerateIdentifier();

            booksList.Add(book);

            return Task.FromResult(true);
        }

        /// <inheritdoc/>
        public Task<bool> DeleteBookAsync(int id)
        {
            var bookForDelete = GetBookById(id);

            var deleteResult = booksList.Remove(bookForDelete);

            return Task.FromResult(deleteResult);
        }

        protected IList<BookDto> GetInitBooks()
            => new List<BookDto>
                {
                    new BookDto{ Id = 1, Title = "Оно", Genre = "Ужасы", Author = "Стивен Кинг", AuthorId = 1 },
                    new BookDto{ Id = 2, Title = "Сияние", Genre = "Триллер", Author = "Стивен Кинг", AuthorId = 1 },
                    new BookDto{ Id = 3, Title = "Зеленая миля", Genre = "Триллер", Author = "Стивен Кинг", AuthorId = 1 },
                    new BookDto{ Id = 4, Title = "Дюна", Genre = "Фантастика", Author = "Фрэнк Герберт", AuthorId = 2 }
                };

        /// <summary>
        /// Получает книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Найденная книга</returns>
        private BookDto GetBookById(int id)
            => booksList.SingleOrDefault(h => h.Id == id);

        private bool BookExistsByTitleAndAuthor(string title, string author)
            => booksList.Any(b => b.Title == title && b.Author == author);

        private int GenerateIdentifier()
            => booksList.Any() ?
            booksList.Max(lc => lc.Id) + identifierIncrementStep :
            identifierInitialValue;
    }
}
