using Microsoft.EntityFrameworkCore;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Data
{
    /// <summary>
    /// 1. Контекст базы данных для работы с библиотекой книг
    /// </summary>
    public sealed class BookLibraryContext : DbContext
    {
        /// <summary>
        /// 2. Набор сущностей жанров книг
        /// </summary>
        public DbSet<Genre> Genres { get; set; }
        /// <summary>
        /// 2. Набор сущностей авторов книг
        /// </summary>
        public DbSet<Author> Authors { get; set; }
        /// <summary>
        /// 2. Набор сущностей книг
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// 2. Набор сущностей пользователей
        /// </summary>
        public DbSet<Person> People { get; set; }
        /// <summary>
        /// 2. Набор сущностей учетных карточек
        /// </summary>
        public DbSet<LibraryCard> LibraryCards { get; set; }

        /// <summary>
        /// Создает новый объект контекста базы данных
        /// </summary>
        /// <param name="options">Настройки, используемые контекстом базы данных</param>
        public BookLibraryContext(DbContextOptions options)
            : base(options) { }
    }
}
