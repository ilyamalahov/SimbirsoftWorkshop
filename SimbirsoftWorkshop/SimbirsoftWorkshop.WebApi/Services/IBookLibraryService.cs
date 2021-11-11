using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Services
{
    /// <summary>
    /// Промежуточный сервис по работе с библиотекой книг
    /// </summary>
    public interface IBookLibraryService
    {
        #region Humans

        /// <summary>
        /// Получает список всех людей
        /// </summary>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> GetAllHumansAsync();
        /// <summary>
        /// Получает список людей, которые пишут книги
        /// </summary>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> GetHumansWhoWriteBooksAsync();
        /// <summary>
        /// Производит поиск людей по имени, фамилии или отчеству
        /// </summary>
        /// <param name="term"></param>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> SearchHumansByTermAsync(string term);
        /// <summary>
        /// Добавляет нового человека
        /// </summary>
        /// <param name="humanDto">Новый человек</param>
        /// <returns>Добавленный человек</returns>
        Task<HumanDto> AddHumanAsync(HumanDto humanDto);
        /// <summary>
        /// Удаляет человека по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор человека</param>
        /// <returns>Результат удаления</returns>
        Task DeleteHumanAsync(int id);

        #endregion

        #region Books

        /// <summary>
        /// Получает список всех книг
        /// </summary>
        /// <param name="model">Модель, включащая в себя параметры строки запроса</param>
        /// <returns>Список книг</returns>
        Task<IEnumerable<BookDto>> GetAllBooksAsync(GetAllBooksModel model);
        /// <summary>
        /// Получает список книг по идентификатору автора
        /// </summary>
        /// <param name="authorId">Идентификатор автора книги</param>
        /// <returns>Список книг</returns>
        Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId);
        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="bookDto">Книга для добавления</param>
        /// <returns>Добавленная книга</returns>
        Task<BookDto> AddBookAsync(BookDto bookDto);
        /// <summary>
        /// Удаляет книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Результат удаления</returns>
        Task DeleteBookAsync(int id);

        #endregion

        #region Library cards

        /// <summary>
        /// Производит получение книги человеком
        /// </summary>
        /// <param name="libraryCardDto">Карточка с данными о получении книги</param>
        /// <returns>Результат получения книги</returns>
        Task TakeBookAsync(LibraryCardDto libraryCardDto);

        #endregion
    }
}
