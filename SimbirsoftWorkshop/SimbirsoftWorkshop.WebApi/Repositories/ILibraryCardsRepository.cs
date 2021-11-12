using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Репозиторий по работе с карточками библиотеки
    /// </summary>
    public interface ILibraryCardsRepository
    {
        /// <summary>
        /// Добавляет новую карточку товара
        /// </summary>
        /// <param name="libraryCard">Новая карточка товара</param>
        /// <returns>Результат добавления</returns>
        bool AddLibraryCard(LibraryCardDto libraryCard);
    }
}
