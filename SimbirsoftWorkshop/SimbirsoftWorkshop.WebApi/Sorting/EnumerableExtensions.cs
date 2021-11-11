using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.Sorting
{
    /// <summary>
    /// Расширение последовательностей для сортировки
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Сортирует последовательность, используя направление сортировки
        /// </summary>
        /// <typeparam name="TElement">Тип элемента последовательности</typeparam>
        /// <typeparam name="TProperty">Тип свойства элемента последовательности</typeparam>
        /// <param name="source">Последовательность, которую нужно отсортировать</param>
        /// <param name="selector">Функция получения свойства элемента</param>
        /// <param name="direction">Направление сортировки</param>
        /// <returns>Отсортированная последовательность</returns>
        public static IOrderedEnumerable<TElement> FirstOrderBy<TElement, TProperty>(this IEnumerable<TElement> source, Func<TElement, TProperty> selector, SortingDirection direction) =>
            direction switch
            {
                SortingDirection.Asc => source.OrderBy(selector),
                SortingDirection.Desc => source.OrderByDescending(selector),
                _ => throw new Exception("Направление сортировки не поддерживается")
            };

        /// <summary>
        /// Выполняет дополнительную сортировку последовательности, используя направление сортировки
        /// </summary>
        /// <typeparam name="TElement">Тип элемента последовательности</typeparam>
        /// <typeparam name="TProperty">Тип свойства элемента последовательности</typeparam>
        /// <param name="source">Последовательность, которую нужно дополнительно отсортировать</param>
        /// <param name="selector">Функция получения свойства элемента</param>
        /// <param name="direction">Направление сортировки</param>
        /// <returns>Отсортированная последовательность</returns>
        public static IOrderedEnumerable<TElement> ThenOrderBy<TElement, TProperty>(this IOrderedEnumerable<TElement> source, Func<TElement, TProperty> selector, SortingDirection direction) =>
            direction switch
            {
                SortingDirection.Asc => source.ThenBy(selector),
                SortingDirection.Desc => source.ThenByDescending(selector),
                _ => throw new Exception("Направление сортировки не поддерживается")
            };
    }
}
