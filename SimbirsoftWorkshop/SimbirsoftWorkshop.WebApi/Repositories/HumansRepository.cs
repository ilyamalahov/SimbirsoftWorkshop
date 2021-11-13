using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с людьми в памяти
    /// </summary>
    public sealed class HumansRepository : IHumansRepository
    {
        private const int identifierInitialValue = 1;
        private const int identifierIncrementStep = 1;

        /// <summary>
        /// 1.2.3 - Статичный список людей
        /// </summary>
        private static readonly IList<HumanDto> humansList = new List<HumanDto>
        {
            new HumanDto 
            { 
                Id = 1, 
                Name = "Зайцева", 
                Surname = "Эмилия", 
                Patronymic = "Романовна", 
                Birthday = new DateTime(1978, 01, 29) 
            },
            new HumanDto 
            { 
                Id = 2, 
                Name = "Комарова", 
                Surname = "Светлана", 
                Patronymic = "Захаровна", 
                Birthday = new DateTime(1992, 05, 17) 
            },
            new HumanDto 
            { 
                Id = 3, 
                Name = "Захаров", 
                Surname = "Максим", 
                Patronymic = "Константинович", 
                Birthday = new DateTime(1985, 12, 04) 
            }
        };

        /// <inheritdoc/>
        public IEnumerable<HumanDto> GetAllHumans()
        {
            return humansList;
        }

        /// <inheritdoc/>
        public IEnumerable<HumanDto> GetHumansByIds(IEnumerable<int> ids)
        {
            if (ids is null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            return humansList.Where(ba => ids.Contains(ba.Id));
        }

        /// <inheritdoc/>
        public IEnumerable<HumanDto> SearchHumansByTerm(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentException($"\"{nameof(term)}\" не может быть неопределенным или пустым.", nameof(term));
            }

            return humansList.Where(h =>
                h.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                h.Surname.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                h.Patronymic.Contains(term, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <inheritdoc/>
        public bool AddHuman(HumanDto human)
        {
            if (human is null)
            {
                throw new ArgumentNullException(nameof(human));
            }

            if (HumanExistsByNameSet(human.Name, human.Surname, human.Patronymic))
            {
                return false;
            }

            human.Id = GenerateIdentifier();

            humansList.Add(human);

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteHumanAsync(int id)
        {
            var humanForDelete = GetHumanById(id);

            return humansList.Remove(humanForDelete);
        }

        /// <summary>
        /// Возвращает человека по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор человека</param>
        /// <returns>Найденный человек</returns>
        private HumanDto GetHumanById(int id)
            => humansList.SingleOrDefault(h => h.Id == id);

        /// <summary>
        /// Проверяет, существует человек по имени, фамилии и отчеству
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="patronymic">Отчество человека</param>
        /// <returns>Результат проверки</returns>
        private bool HumanExistsByNameSet(string name, string surname, string patronymic)
            => humansList.Any(h =>
                h.Name == name &&
                h.Surname == surname &&
                h.Patronymic == patronymic);

        private int GenerateIdentifier()
            => humansList.Any() ?
            humansList.Max(lc => lc.Id) + identifierIncrementStep :
            identifierInitialValue;
    }
}
