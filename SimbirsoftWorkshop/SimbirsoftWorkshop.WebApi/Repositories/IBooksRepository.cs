using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Репозиторий для работы с книгами
    /// </summary>
    public interface IBooksRepository
    {
        /// <summary>
        /// Получает список всех книг
        /// </summary>
        /// <returns>Список книг</returns>
        IEnumerable<BookDto> GetAllBooks(GetAllBooksModel model);
        /// <summary>
        /// Получает книги по идентификатору автора
        /// </summary>
        /// <param name="authorId">Идентификатор автора книг</param>
        /// <returns>Список книг</returns>
        IEnumerable<BookDto> GetBooksByAuthorId(int authorId);
        /// <summary>
        /// Получает список идентификаторов авторов книг
        /// </summary>
        /// <returns>Список идентификаторов авторов книг</returns>
        IEnumerable<int> GetBookAuthorsIds();
        /// <summary>
        /// Добавляет новую книгу
        /// </summary>
        /// <param name="book">Новая книга</param>
        /// <returns>Результат добавления новой книги (добавлена/не добавлена)</returns>
        bool AddBook(BookDto book);
        /// <summary>
        /// Удаляет книгу
        /// </summary>
        /// <param name="id">Идентификатор удаляемой книги</param>
        /// <returns>Результат удаления книги (удалена/не удалена)</returns>
        bool DeleteBook(int id);
    }
}
