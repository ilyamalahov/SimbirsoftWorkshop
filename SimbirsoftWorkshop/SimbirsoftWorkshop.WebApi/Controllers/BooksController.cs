using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Services;

namespace SimbirsoftWorkshop.WebApi.Controllers
{
    /// <summary>
    /// 1.4 - API-контроллер книг
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Сервис по работе с библиотекой книг
        /// </summary>
        private readonly IBookLibraryService humanBookService;

        /// <summary>
        /// Создает новый объект контроллера
        /// </summary>
        /// <param name="humanBookService">Сервис по работе с библиотекой книг</param>
        public BooksController(IBookLibraryService humanBookService)
        {
            this.humanBookService = humanBookService;
        }

        /// <summary>
        /// 1.4.1.1 - Получает список всех книг
        /// </summary>
        /// <param name="model">Модель, включащая в себя параметры строки запроса</param>
        /// <returns>Список книг</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<BookDto>> GetAllBooksAsync([FromQuery] GetAllBooksModel model)
        {
            return await humanBookService.GetAllBooksAsync(model);
        }

        /// <summary>
        /// 1.4.1.2 - Получает список книг по идентификатору автора
        /// </summary>
        /// <param name="authorId">Идентификатор автора книги</param>
        /// <returns>Список книг</returns>
        [HttpGet("by-author/{authorId}")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<BookDto>> GetBooksByAuthorId([FromRoute] int authorId)
        {
            return await humanBookService.GetBooksByAuthorIdAsync(authorId);
        }

        /// <summary>
        /// 1.4.2 - Добавляет книгу
        /// </summary>
        /// <param name="bookDto">Книга для добавления</param>
        /// <returns>Добавленная книга</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookDto), 200)]
        [ProducesResponseType(500)]
        public async Task<BookDto> AddBookAsync([FromBody] BookDto bookDto)
        {
            return await humanBookService.AddBookAsync(bookDto);
        }

        /// <summary>
        /// 1.4.3 - Удаляет книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(500)]
        public async Task DeleteBookAsync([FromRoute] int id)
        {
            await humanBookService.DeleteBookAsync(id);
        }
    }
}
