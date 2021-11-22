using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    public interface ILibraryCardsRepository
    {
        Task<LibraryCard> GetLibraryCardAsync(int personId, int bookId);
        Task AddLibraryCardAsync(LibraryCard libraryCard);
        Task DeleteLibraryCardAsync(LibraryCard libraryCard);
    }
}
