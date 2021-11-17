using System.Collections.Generic;

namespace SimbirsoftWorkshop.WebApi.Entities
{
    /// <summary>
    /// 2. Автор книги
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя автора
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия автора
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество автора
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Книги автора
        /// </summary>
        public ICollection<Book> Books { get; set; }
    }
}
