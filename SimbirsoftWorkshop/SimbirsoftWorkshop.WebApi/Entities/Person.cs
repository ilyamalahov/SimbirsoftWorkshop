using System;
using System.Collections.Generic;

namespace SimbirsoftWorkshop.WebApi.Entities
{
    /// <summary>
    /// 2. Пользователь
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Book> Books { get; set; }
        /// <summary>
        /// Учетные карточки пользователя
        /// </summary>
        public List<LibraryCard> LibraryCards { get; set; }
    }
}
