using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Repositories;

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
        /// Репозиторий для работы с людьми
        /// </summary>
        private readonly IHumansRepository humansRepository;
        /// <summary>
        /// Репозиторий для работы с книгами
        /// </summary>
        private readonly IBooksRepository booksRepository;

        /// <summary>
        /// Создает новый контроллер
        /// </summary>
        /// <param name="humansRepository">Репозиторий для работы с людьми</param>
        /// <param name="booksRepository">Репозиторий для работы с книгами</param>
        public HumansController(IHumansRepository humansRepository, IBooksRepository booksRepository)
        {
            this.humansRepository = humansRepository;
            this.booksRepository = booksRepository;
        }

        /// <summary>
        /// 1.3.1.1 - Получает список всех людей
        /// </summary>
        /// <returns>Список людей</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<HumanDto> GetAllHumans()
        {
            return humansRepository.GetAllHumans();
        }

        /// <summary>
        /// 1.3.1.2 - Получает список людей, которые пишут книги
        /// </summary>
        /// <returns>Список людей</returns>
        [HttpGet("who-write-books")]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<HumanDto> GetHumansWhoWriteBooks()
        {
            var humanIds = booksRepository.GetBookAuthorsIds();

            return humansRepository.GetHumansByIds(humanIds);
        }

        /// <summary>
        /// 1.3.1.3 - Производит поиск людей по имени, фамилии или отчеству
        /// </summary>
        /// <param name="term"></param>
        /// <returns>Список людей</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<HumanDto>), 200)]
        [ProducesResponseType(500)]
        public IEnumerable<HumanDto> Search([FromQuery] string term)
        {
            return humansRepository.SearchHumansByTerm(term);
        }

        /// <summary>
        /// 1.3.2 Добавляет нового человека
        /// </summary>
        /// <param name="humanDto">Новый человек</param>
        /// <returns>Добавленный человек</returns>
        [HttpPost]
        [ProducesResponseType(typeof(HumanDto), 200)]
        [ProducesResponseType(500)]
        public HumanDto AddHuman([FromBody] HumanDto humanDto)
        {
            humansRepository.AddHuman(humanDto);

            return humanDto;
        }

        /// <summary>
        /// 1.3.3 Удаляет человека по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор человека</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public void DeleteHuman([FromRoute] int id)
        {
            humansRepository.DeleteHumanAsync(id);
        }
    }
}
