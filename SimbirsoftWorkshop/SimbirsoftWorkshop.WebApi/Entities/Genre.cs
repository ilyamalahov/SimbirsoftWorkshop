using System.Collections.Generic;

namespace SimbirsoftWorkshop.WebApi.Entities
{
    /// <summary>
    /// 2. Жанр книги
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название жанра
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Книги жанра
        /// </summary>
        public ICollection<Book> Books { get; set; }
    }
}
