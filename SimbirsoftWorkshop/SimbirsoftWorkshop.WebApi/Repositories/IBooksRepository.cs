using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// 6. Репозиторий для работы с книгами
    /// </summary>
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooksByPersonIdAsync(int personId);
    }
}
