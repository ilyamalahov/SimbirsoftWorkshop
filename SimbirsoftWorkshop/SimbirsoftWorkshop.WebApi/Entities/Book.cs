using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.Entities
{
    /// <summary>
    /// 2. Книга
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор автора книги
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Жанры книги
        /// </summary>
        public ICollection<Genre> Genres { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Person> People { get; set; }
        /// <summary>
        /// Учетные карточки книги
        /// </summary>
        public List<LibraryCard> LibraryCards { get; set; }
    }
}
