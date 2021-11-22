using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// 6. Репозиторий для работы с пользователями
    /// </summary>
    public interface IPeopleRepository
    {
        Task<IEnumerable<Person>> SearchPeopleByFullNameAsync(string firstName, string lastName, string middleName);
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> GetPersonWithChildrenAsync(int id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
        Task DeletePeopleAsync(IEnumerable<Person> people);
    }
}
