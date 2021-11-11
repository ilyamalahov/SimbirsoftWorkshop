using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Репозиторий по работе с людьми
    /// </summary>
    public interface IHumansRepository
    {
        /// <summary>
        /// Получает список всех людей
        /// </summary>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> GetAllHumansAsync();
        /// <summary>
        /// Получает список людей по их идентификаторам
        /// </summary>
        /// <param name="ids">Идентификаторы людей</param>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> GetHumansByIdsAsync(IEnumerable<int> ids);
        /// <summary>
        /// Производит поиск людей по имени, фамилии или отчеству
        /// </summary>
        /// <param name="term">Искомое выражение</param>
        /// <returns>Список людей</returns>
        Task<IEnumerable<HumanDto>> SearchHumansByTermAsync(string term);
        /// <summary>
        /// Добавляет нового человека
        /// </summary>
        /// <param name="human">Новый человек</param>
        /// <returns>Результат добавления</returns>
        Task<bool> AddHumanAsync(HumanDto human);
        /// <summary>
        /// Удаляет человека по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор человека</param>
        /// <returns>Результат удаления</returns>
        Task<bool> DeleteHumanAsync(int id);
    }
}
