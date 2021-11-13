using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.Models
{
    /// <summary>
    /// 1.2.1 - Человек (Пользователь системы)
    /// </summary>
    public sealed class HumanDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required]
        public string Surname { get; set; }
        /// <summary>
        /// Отчество пользователя
        /// </summary>
        [Required]
        public string Patronymic { get; set; }
        /// <summary>
        /// День рождения пользователя
        /// </summary>
        [Required]
        public DateTime Birthday { get; set; }
    }
}
