using System.Collections.Generic;
using System.Linq;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с карточками библиотеки в памяти
    /// </summary>
    public sealed class LibraryCardsRepository : ILibraryCardsRepository
    {
        private const int identifierInitialValue = 1;
        private const int identifierIncrementStep = 1;

        /// <summary>
        /// 2.1.3 - Статичный список карточек библиотеки
        /// </summary>
        private static readonly IList<LibraryCardDto> libraryCardsList = new List<LibraryCardDto>();

        /// <inheritdoc/>
        public bool AddLibraryCard(LibraryCardDto libraryCard)
        {
            if (GetLibraryCardExistsById(libraryCard.Id))
            {
                return false;
            }

            libraryCard.Id = GenerateIdentifier();

            libraryCardsList.Add(libraryCard);

            return true;
        }

        /// <summary>
        /// Получает книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Найденная книга</returns>
        private bool GetLibraryCardExistsById(int id)
            => libraryCardsList.Any(lc => lc.Id == id);

        private int GenerateIdentifier()
            => libraryCardsList.Any() ?
            libraryCardsList.Max(lc => lc.Id) + identifierIncrementStep :
            identifierInitialValue;
    }
}
