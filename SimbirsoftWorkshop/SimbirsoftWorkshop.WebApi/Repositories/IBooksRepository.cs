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
        Task<IEnumerable<BookDto>> GetAllBooksAsync(GetAllBooksModel model);
        /// <summary>
        /// Получает книги по идентификатору автора
        /// </summary>
        /// <param name="authorId">Идентификатор автора книг</param>
        /// <returns>Список книг</returns>
        Task<IEnumerable<BookDto>> GetBooksByAuthorId(int authorId);
        /// <summary>
        /// Получает список идентификаторов авторов книг
        /// </summary>
        /// <returns>Список идентификаторов авторов книг</returns>
        Task<IEnumerable<int>> GetBookAuthorsIdsAsync();
        /// <summary>
        /// Добавляет новую книгу
        /// </summary>
        /// <param name="book">Новая книга</param>
        /// <returns>Результат добавления новой книги (добавлена/не добавлена)</returns>
        Task<bool> AddBookAsync(BookDto book);
        /// <summary>
        /// Удаляет книгу
        /// </summary>
        /// <param name="id">Идентификатор удаляемой книги</param>
        /// <returns>Результат удаления книги (удалена/не удалена)</returns>
        Task<bool> DeleteBookAsync(int id);
    }
}
