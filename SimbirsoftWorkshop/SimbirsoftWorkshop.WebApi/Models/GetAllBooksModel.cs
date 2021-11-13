using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimbirsoftWorkshop.WebApi.Sorting;

namespace SimbirsoftWorkshop.WebApi.Models
{
    /// <summary>
    /// Модель, включащая в себя параметры строки запроса
    /// </summary>
    public class GetAllBooksModel
    {
        /// <summary>
        /// Список моделей сортироки объекта
        /// </summary>
        [BindProperty(Name = "sortings", SupportsGet = true)]
        public IEnumerable<SortingModel> Sortings { get; set; }
    }
}
