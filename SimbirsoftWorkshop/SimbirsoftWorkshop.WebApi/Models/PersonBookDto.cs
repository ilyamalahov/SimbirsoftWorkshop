using System.Collections.Generic;

namespace SimbirsoftWorkshop.WebApi.Models
{
    public class PersonBookDto
    {
        /// <summary>
        /// Идентфикатор книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
        public PersonBookAuthorDto Author { get; set; }
        /// <summary>
        /// Жанры книги
        /// </summary>
        public IEnumerable<PersonBookGenreDto> Genres { get; set; }
    }
}
