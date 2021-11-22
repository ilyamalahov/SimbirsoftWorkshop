using System;

namespace SimbirsoftWorkshop.WebApi.Entities
{
    /// <summary>
    /// 2. Учетная карточка
    /// </summary>
    public class LibraryCard
    {
        /// <summary>
        /// Уникальный идентификатор книги
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Книга
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public Person Person { get; set; }
        /// <summary>
        /// Дата и время получения книги пользователем
        /// </summary>
        public DateTimeOffset BookReceivingDate { get; set; }
    }
}
