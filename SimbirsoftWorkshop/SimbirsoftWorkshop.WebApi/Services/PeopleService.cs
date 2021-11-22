using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SimbirsoftWorkshop.WebApi.Data;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Extensions;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Repositories;

namespace SimbirsoftWorkshop.WebApi.Services
{
    public class PeopleService : BookLibraryServiceBase, IPeopleService
    {
        private readonly ILogger<PeopleService> logger;
        private readonly IMapper mapper;
        private readonly IPeopleRepository peopleRepository;
        private readonly IBooksRepository booksRepository;
        private readonly ILibraryCardsRepository libraryCardsRepository;

        public PeopleService(
            ILogger<PeopleService> logger,
            IMapper mapper,
            IPeopleRepository peopleRepository,
            IBooksRepository booksRepository,
            ILibraryCardsRepository libraryCardsRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.peopleRepository = peopleRepository;
            this.booksRepository = booksRepository;
            this.libraryCardsRepository = libraryCardsRepository;
        }

        /// <summary>
        /// Добавляет нового пользователя
        /// </summary>
        /// <param name="personDto">Новый пользователь</param>
        /// <returns>Добавленный пользователь</returns>
        public async Task<ServiceResult> AddPersonAsync(PersonDto personDto)
        {
            if (personDto is null)
            {
                throw new ArgumentNullException(nameof(personDto));
            }

            try
            {
                var person = mapper.Map<Person>(personDto);

                await peopleRepository.AddPersonAsync(person);

                mapper.Map(person, personDto);

                return Success(personDto);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception, 
                    "Произошла ошибка при добавлении пользователя ({0})", 
                    personDto);

                throw;
            }
        }

        /// <summary>
        /// Изменяет информации о пользователе по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <param name="personDto">Пользователь с измененными данными</param>
        /// <returns>Результат измения информации о пользователе</returns>
        public async Task<ServiceResult> UpdatePersonAsync(int id, PersonDto personDto)
        {
            try
            {
                var person = await peopleRepository.GetPersonByIdAsync(id);

                if (person == null)
                {
                    return Error("Пользователь с идентификтором {0} не найден", id);
                }

                mapper.Map(personDto, person);

                await peopleRepository.UpdatePersonAsync(person);

                mapper.Map(person, personDto);

                return Success(personDto);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception, 
                    "Произошла ошибка при обновлении пользователя {0} ({1})", 
                    id, 
                    personDto);

                throw;
            }
        }

        /// <summary>
        /// Удаляет пользователя по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns>Результат удаления</returns>
        public async Task<ServiceResult> DeletePersonAsync(int id)
        {
            try
            {
                var person = await peopleRepository.GetPersonByIdAsync(id);

                if (person == null)
                {
                    return Error("Пользователь с идентификтором {0} не существует", id);
                }

                await peopleRepository.DeletePersonAsync(person);

                return Success();
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception, 
                    "Произошла ошибка при удалении пользователя {0}", 
                    id);

                throw;
            }
        }

        public async Task<ServiceResult> DeletePeopleByFullNameAsync(DeletePeopleByFullNameModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                var people = await peopleRepository.SearchPeopleByFullNameAsync(model.FirstName, model.LastName, model.MiddleName);

                if (!people.Any())
                {
                    return Error(
                        "Пользователи с именем \"{0}\" не найдены",
                        model.GetFullName());
                }

                await peopleRepository.DeletePeopleAsync(people);

                return Success();
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception, 
                    "Произошла ошибка при удалении пользователей по имени \"{0}\"", 
                    model);

                throw;
            }
        }

        public async Task<ServiceResult> GetPersonBooksAsync(int personId)
        {
            try
            {
                var books = await booksRepository.GetBooksByPersonIdAsync(personId);

                var personBookDtos = mapper.Map<IEnumerable<PersonBookDto>>(books);

                return Success(personBookDtos);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception,
                    "Произошла ошибка при получении списка книг пользователя {1}",
                    personId);

                throw;
            }
        }

        #region Receiving book

        public async Task<ServiceResult> PersonReceivesBookAsync(int personId, int bookId)
        {
            try
            {
                var libraryCard = await libraryCardsRepository.GetLibraryCardAsync(personId, bookId);

                if (libraryCard != null)
                {
                    var errorPerson = await peopleRepository.GetPersonByIdAsync(libraryCard.PersonId);

                    return Error(
                        "Ошибка при получении книги: книга уже взята пользователем \"{0}\"",
                        errorPerson.GetFullName());
                }

                libraryCard = new LibraryCard
                {
                    PersonId = personId,
                    BookId = bookId
                };

                await libraryCardsRepository.AddLibraryCardAsync(libraryCard);

                var person = await peopleRepository.GetPersonWithChildrenAsync(personId);

                var receivingBookPersonDto = mapper.Map<ReceivingBookPersonDto>(person);

                return Success(receivingBookPersonDto);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception,
                    "Произошла ошибка при получении книги {0} пользователем {1}",
                    bookId,
                    personId);

                throw;
            }
        }

        public async Task<ServiceResult> PersonReturnsBookAsync(int personId, int bookId)
        {
            try
            {
                var libraryCard = await libraryCardsRepository.GetLibraryCardAsync(personId, bookId);

                if (libraryCard == null)
                {
                    return Error("Попытка возврата книги по несуществующей карточке");
                }

                await libraryCardsRepository.DeleteLibraryCardAsync(libraryCard);

                var person = await peopleRepository.GetPersonWithChildrenAsync(personId);

                var receivingBookPersonDto = mapper.Map<ReceivingBookPersonDto>(person);

                return Success(receivingBookPersonDto);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception, 
                    "Произошла ошибка при возврате книги {0} пользователем {1}", 
                    bookId,
                    personId);

                throw;
            }
        }

        #endregion
    }

    public interface IPeopleService
    {
        Task<ServiceResult> AddPersonAsync(PersonDto personDto);
        Task<ServiceResult> UpdatePersonAsync(int id, PersonDto personDto);
        Task<ServiceResult> DeletePersonAsync(int id);
        Task<ServiceResult> DeletePeopleByFullNameAsync(DeletePeopleByFullNameModel model);
        Task<ServiceResult> GetPersonBooksAsync(int personId);
        Task<ServiceResult> PersonReceivesBookAsync(int personId, int bookId);
        Task<ServiceResult> PersonReturnsBookAsync(int personId, int bookId);
    }
}
