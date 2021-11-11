using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Services;

namespace SimbirsoftWorkshop.WebApi.Controllers
{
    /// <summary>
    /// 1.3 - API-контроллер по работе с людьми
    /// </summary>
    [Route("api/humans")]
    [ApiController]
    public class HumansController : ControllerBase
    {
        /// <summary>
        /// Сервис по работе с библиотекой книг
        /// </summary>
        private readonly IBookLibraryService humanBookService;

        /// <summary>
        /// Создает новый контроллер
        /// </summary>
        /// <param name="humanBookService">Сервис по работе с библиотекой книг</param>
        public HumansController(IBookLibraryService humanBookService)
        {
            this.humanBookService = humanBookService;
        }

        /// <summary>
        /// 1.3.1.1 - Получает список всех людей
        /// </summary>
        /// <returns>Список людей</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<HumanDto>> GetAllHumansAsync()
        {
            return await humanBookService.GetAllHumansAsync();
        }

        /// <summary>
        /// 1.3.1.2 - Получает список людей, которые пишут книги
        /// </summary>
        /// <returns>Список людей</returns>
        [HttpGet("who-write-books")]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<HumanDto>> GetHumansWhoWriteBooksAsync()
        {
            return await humanBookService.GetHumansWhoWriteBooksAsync();
        }

        /// <summary>
        /// 1.3.1.3 - Производит поиск людей по имени, фамилии или отчеству
        /// </summary>
        /// <param name="term"></param>
        /// <returns>Список людей</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<HumanDto>> SearchAsync([FromQuery] string term)
        {
            return await humanBookService.SearchHumansByTermAsync(term);
        }

        /// <summary>
        /// 1.3.2 Добавляет нового человека
        /// </summary>
        /// <param name="humanDto">Новый человек</param>
        /// <returns>Добавленный человек</returns>
        [HttpPost]
        [ProducesResponseType(typeof(HumanDto), 200)]
        [ProducesResponseType(500)]
        public async Task<HumanDto> AddHumanAsync([FromBody] HumanDto humanDto)
        {
            return await humanBookService.AddHumanAsync(humanDto);
        }

        /// <summary>
        /// 1.3.3 Удаляет человека по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор человека</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task DeleteHumanAsync([FromRoute] int id)
        {
            await humanBookService.DeleteHumanAsync(id);
        }
    }
}
