using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly IList<BookDto> booksList = new List<BookDto>
        {
            new BookDto
            {
                Id = 1,
                Title = "Оно",
                Genre = "Ужасы",
                Author = "Стивен Кинг",
                AuthorId = 1
            },
            new BookDto
            {
                Id = 2,
                Title = "Сияние",
                Genre = "Триллер",
                Author = "Стивен Кинг",
                AuthorId = 1
            },
            new BookDto
            {
                Id = 4,
                Title = "Дюна",
                Genre = "Фантастика",
                Author = "Фрэнк Герберт",
                AuthorId = 2
            }
        };

        /// <inheritdoc/>
        public IEnumerable<BookDto> GetAllBooks(GetAllBooksModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return SortingHelper.SortBooks(booksList, model.Sortings);
        }

        /// <inheritdoc/>
        public IEnumerable<BookDto> GetBooksByAuthorId(int authorId)
        {
            return booksList.Where(b => b.AuthorId == authorId);
        }

        /// <inheritdoc/>
        public IEnumerable<int> GetBookAuthorsIds()
        {
            return booksList.Select(b => b.AuthorId).Distinct();
        }

        /// <inheritdoc/>
        public bool AddBook(BookDto book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (BookExistsByTitleAndAuthor(book.Title, book.Author))
            {
                return false;
            }

            book.Id = GenerateIdentifier();

            booksList.Add(book);

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteBook(int id)
        {
            var bookForDelete = GetBookById(id);

            return booksList.Remove(bookForDelete);
        }

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
