using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirsoftWorkshop.WebApi.Models
{
    /// <summary>
    /// 2.1.1 - Карточка библиотеки
    /// </summary>
    public sealed class LibraryCardDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор человека, взявшего для прочтения книгу
        /// </summary>
        [Required]
        public int HumanId { get; set; }
        /// <summary>
        /// Дата и время получения книги человеком
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTimeOffset BookTakingDate { get; set; }
    }
}
