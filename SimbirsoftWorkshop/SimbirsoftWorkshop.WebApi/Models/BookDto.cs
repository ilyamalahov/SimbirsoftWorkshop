using System.ComponentModel.DataAnnotations;

namespace SimbirsoftWorkshop.WebApi.Models
{
    /// <summary>
    /// 1.2.2 - Книга
    /// </summary>
    public sealed class BookDto
    {
        /// <summary>
        /// Уникальный идентфикатор книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        /// <summary>
        /// Жанр книги
        /// </summary>
        [Required]
        [StringLength(35)]
        public string Genre { get; set; }
        /// <summary>
        /// Автор книги (Фамилия Имя Отчество)
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Author { get; set; }
        /// <summary>
        /// Уникальный идентификатор автора книги
        /// </summary>
        [Required]
        public int AuthorId { get; set; }
    }
}
