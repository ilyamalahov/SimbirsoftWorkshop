using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Services;

namespace SimbirsoftWorkshop.WebApi.Controllers
{
    /// <summary>
    /// 2.1.2 - API-контроллер библиотеки
    /// </summary>
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        /// <summary>
        /// Сервис по работе с библиотекой книг
        /// </summary>
        private readonly IBookLibraryService humanBookService;

        /// <summary>
        /// Создает новый объект контроллера
        /// </summary>
        /// <param name="humanBookService">Сервис по работе с библиотекой книг</param>
        public LibraryController(IBookLibraryService humanBookService)
        {
            this.humanBookService = humanBookService;
        }

        /// <summary>
        /// 2.1.4 - Производит получение книги человеком
        /// </summary>
        /// <param name="libraryCardDto">Карточка с данными о получении книги</param>
        /// <returns>Результат получения книги</returns>
        [HttpPost("take-book")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task TakeBookAsync([FromBody] LibraryCardDto libraryCardDto)
        {
            await humanBookService.TakeBookAsync(libraryCardDto);
        }
    }
}
