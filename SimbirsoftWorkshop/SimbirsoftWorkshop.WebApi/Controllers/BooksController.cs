using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Repositories;

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
        /// Репозиторий для работы с книгами
        /// </summary>
        private readonly IBooksRepository booksRepository;

        /// <summary>
        /// Создает новый объект контроллера
        /// </summary>
        /// <param name="booksRepository">Репозиторий для работы с книгами</param>
        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        /// <summary>
        /// 1.4.1.1 - Получает список всех книг
        /// </summary>
        /// <param name="model">Модель, включащая в себя параметры строки запроса</param>
        /// <returns>Список книг</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<BookDto> GetAllBooks([FromQuery] GetAllBooksModel model)
        {
            return booksRepository.GetAllBooks(model);
        }

        /// <summary>
        /// 1.4.1.2 - Получает список книг по идентификатору автора
        /// </summary>
        /// <param name="authorId">Идентификатор автора книги</param>
        /// <returns>Список книг</returns>
        [HttpGet("by-author/{authorId}")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<BookDto> GetBooksByAuthorId([FromRoute] int authorId)
        {
            return booksRepository.GetBooksByAuthorId(authorId);
        }

        /// <summary>
        /// 1.4.2 - Добавляет книгу
        /// </summary>
        /// <param name="bookDto">Книга для добавления</param>
        /// <returns>Добавленная книга</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookDto), 200)]
        [ProducesResponseType(500)]
        public BookDto AddBook([FromBody] BookDto bookDto)
        {
            booksRepository.AddBook(bookDto);

            return bookDto;
        }

        /// <summary>
        /// 1.4.3 - Удаляет книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(500)]
        public void DeleteBook([FromRoute] int id)
        {
            booksRepository.DeleteBook(id);
        }
    }
}
