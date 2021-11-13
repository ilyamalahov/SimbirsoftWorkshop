using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.Extensions
{
    /// <summary>
    /// Метод расширения объектов IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Возвращает уникальные элементы из последовательности, используя свойство элемента
        /// </summary>
        /// <typeparam name="TElement">Тип элемента</typeparam>
        /// <typeparam name="TProperty">Тип свойства элемента</typeparam>
        /// <param name="source">Последовательность с дублирующими элементами</param>
        /// <param name="selector">Функция получения свойства элемента</param>
        /// <returns>Последовательность с уникальными элементами</returns>
        public static IEnumerable<TElement> Distinct<TElement, TProperty>(this IEnumerable<TElement> source, Func<TElement, TProperty> selector)
            => source.GroupBy(selector).Select(g => g.First());

        /// <summary>
        /// Проверяет, что последовательность не равна null и не пустая
        /// </summary>
        /// <typeparam name="TElement">Тип элемента последовательности</typeparam>
        /// <param name="source">Проверяемая последовательность</param>
        /// <returns>Результат проверки</returns>
        public static bool NotNullAndAny<TElement>(this IEnumerable<TElement> source)
            => source != null && source.Any();
    }
}
