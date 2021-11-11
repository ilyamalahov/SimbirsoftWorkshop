using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.Sorting
{
    /// <summary>
    /// Модель сортировки
    /// </summary>
    public class SortingModel
    {
        /// <summary>
        /// Название свойства объекта
        /// </summary>
        [Required]
        public string ColumnName { get; set; }
        /// <summary>
        /// Направление сортировки
        /// </summary>
        [Required]
        public SortingDirection Direction { get; set; }
    }
}
