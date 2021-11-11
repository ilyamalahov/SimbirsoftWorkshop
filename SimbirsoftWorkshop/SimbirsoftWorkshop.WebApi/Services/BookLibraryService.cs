using System.Collections.Generic;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Repositories;

namespace SimbirsoftWorkshop.WebApi.Services
{
    /// <summary>
    /// Реализация сервиса по работе с библиотекой книг
    /// </summary>
    public sealed class BookLibraryService : IBookLibraryService
    {
        private readonly IBooksRepository booksRepository;
        private readonly IHumansRepository humansRepository;
        private readonly ILibraryCardsRepository libraryCardsRepository;

        /// <summary>
        /// Создает новый объект сервиса
        /// </summary>
        /// <param name="booksRepository">Репозиторий для работы с книгами</param>
        /// <param name="humansRepository"></param>
        /// <param name="libraryCardsRepository"></param>
        public BookLibraryService(
            IBooksRepository booksRepository,
            IHumansRepository humansRepository, 
            ILibraryCardsRepository libraryCardsRepository)
        {
            this.booksRepository = booksRepository;
            this.humansRepository = humansRepository;
            this.libraryCardsRepository = libraryCardsRepository;
        }

        #region Humans

        /// <inheritdoc/>
        public async Task<IEnumerable<HumanDto>> GetAllHumansAsync()
        {
            return await humansRepository.GetAllHumansAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<HumanDto>> GetHumansWhoWriteBooksAsync()
        {
            var humanIds = await booksRepository.GetBookAuthorsIdsAsync();

            return await humansRepository.GetHumansByIdsAsync(humanIds);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<HumanDto>> SearchHumansByTermAsync(string term)
        {
            return await humansRepository.SearchHumansByTermAsync(term);
        }

        /// <inheritdoc/>
        public async Task<HumanDto> AddHumanAsync(HumanDto humanDto)
        {
            await humansRepository.AddHumanAsync(humanDto);

            return humanDto;
        }

        /// <inheritdoc/>
        public async Task DeleteHumanAsync(int id)
        {
            await humansRepository.DeleteHumanAsync(id);
        }

        #endregion

        #region Books

        /// <inheritdoc/>
        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(GetAllBooksModel model)
        {
            return await booksRepository.GetAllBooksAsync(model);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await booksRepository.GetBooksByAuthorId(authorId);
        }

        /// <inheritdoc/>
        public async Task<BookDto> AddBookAsync(BookDto bookDto)
        {
            await booksRepository.AddBookAsync(bookDto);

            return bookDto;
        }

        /// <inheritdoc/>
        public async Task DeleteBookAsync(int id)
        {
            await booksRepository.DeleteBookAsync(id);
        }

        #endregion

        #region Taking book

        /// <inheritdoc/>
        public async Task TakeBookAsync(LibraryCardDto libraryCardDto)
        {
            await libraryCardsRepository.AddLibraryCardAsync(libraryCardDto);
        }

        #endregion
    }
}
