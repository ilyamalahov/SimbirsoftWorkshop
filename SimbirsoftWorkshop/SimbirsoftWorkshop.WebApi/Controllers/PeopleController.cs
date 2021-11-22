using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Services;

namespace SimbirsoftWorkshop.WebApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        /// <summary>
        /// 7.1.1. Добавляет нового пользователя
        /// </summary>
        /// <param name="personDto">Новый пользователь</param>
        /// <returns>Результат добавления нового пользователя</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PersonDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult> AddPersonAsync([FromBody] PersonDto personDto)
        {
            var serviceResult = await peopleService.AddPersonAsync(personDto);

            return serviceResult switch
            {
                SuccessServiceResult<PersonDto> successResult => CreatedAtAction(nameof(AddPersonAsync), successResult.Value),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.2. Изменяет информацию о пользователе по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <param name="personDto">Пользователь с измененными данными</param>
        /// <returns>Результат изменения информации о пользователе</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePersonAsync([FromRoute] int id, [FromBody] PersonDto personDto)
        {
            var serviceResult = await peopleService.UpdatePersonAsync(id, personDto);

            return serviceResult switch
            {
                SuccessServiceResult<PersonDto> successResult => Ok(successResult.Value),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.3. Удаляет пользователя по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns>Результат удаления пользователя</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePersonAsync([FromRoute] int id)
        {
            var serviceResult = await peopleService.DeletePersonAsync(id);

            return serviceResult switch
            {
                SuccessServiceResult => Ok(),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.4. Удаляет пользователей по найденному ФИО
        /// </summary>
        /// <param name="model">Модель, содержащая ФИО пользователя</param>
        /// <returns>Результат удаления пользователей</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("by-fullname")]
        public async Task<ActionResult> DeletePeopleByFullName([FromBody] DeletePeopleByFullNameModel model)
        {
            var serviceResult = await peopleService.DeletePeopleByFullNameAsync(model);

            return serviceResult switch
            {
                SuccessServiceResult => Ok(),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.5. Получает список всех взятых пользователем книг
        /// </summary>
        /// <param name="personId">Пользователь, который взял книгу</param>
        /// <returns>Список книг, взятых пользователем</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<PersonBookDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("{personId:int}/books")]
        public async Task<ActionResult> GetPersonBooks([FromRoute] int personId)
        {
            var serviceResult = await peopleService.GetPersonBooksAsync(personId);

            return serviceResult switch
            {
                SuccessServiceResult<IEnumerable<PersonBookDto>> successResult => Ok(successResult.Value),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.6. Получает книгу для прочтения пользователем
        /// </summary>
        /// <param name="personId">Пользователь, который получает книгу для прочтения</param>
        /// <param name="bookId">Книга, которую пользователь получает для прочтения</param>
        /// <returns>Пользователь со списком взятых для прочтения книг</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ReceivingBookPersonDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("{personId:int}/books/{bookId:int}/receive")]
        public async Task<ActionResult> PersonReceivesBook([FromRoute] int personId, [FromRoute] int bookId)
        {
            var serviceResult = await peopleService.PersonReceivesBookAsync(personId, bookId);

            return serviceResult switch
            {
                SuccessServiceResult<ReceivingBookPersonDto> successResult => Ok(successResult.Value),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// 7.1.7. Возвращает книгу, взятую для прочтения пользователем
        /// </summary>
        /// <param name="personId">Пользователь, который возвращает книгу</param>
        /// <param name="bookId">Книга, которую пользователь возвращает</param>
        /// <returns>Пользователь со списком взятых для прочтения книг</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ReceivingBookPersonDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("{personId:int}/books/{bookId:int}/return")]
        public async Task<ActionResult> PersonReturnsBook([FromRoute] int personId, [FromRoute] int bookId)
        {
            var serviceResult = await peopleService.PersonReturnsBookAsync(personId, bookId);

            return serviceResult switch
            {
                SuccessServiceResult<ReceivingBookPersonDto> successResult => Ok(successResult.Value),
                ErrorServiceResult errorResult => BadRequest(errorResult.ErrorMessage),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
