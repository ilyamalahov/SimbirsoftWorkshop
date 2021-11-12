using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Repositories;

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
        /// Репозиторий по работе с карточками библиотеки
        /// </summary>
        private readonly ILibraryCardsRepository libraryCardsRepository;

        /// <summary>
        /// Создает новый объект контроллера
        /// </summary>
        /// <param name="libraryCardsRepository">Репозиторий по работе с карточками библиотеки</param>
        public LibraryController(ILibraryCardsRepository libraryCardsRepository)
        {
            this.libraryCardsRepository = libraryCardsRepository;
        }

        /// <summary>
        /// 2.1.4 - Производит получение книги человеком
        /// </summary>
        /// <param name="libraryCardDto">Карточка с данными о получении книги</param>
        /// <returns>Результат получения книги</returns>
        [HttpPost("take-book")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public void TakeBookAsync([FromBody] LibraryCardDto libraryCardDto)
        {
            libraryCardsRepository.AddLibraryCard(libraryCardDto);
        }
    }
}
