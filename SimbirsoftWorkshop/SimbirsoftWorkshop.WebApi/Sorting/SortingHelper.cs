using System;
using System.Collections.Generic;
using System.Linq;
using SimbirsoftWorkshop.WebApi.Models;
using SimbirsoftWorkshop.WebApi.Extensions;

namespace SimbirsoftWorkshop.WebApi.Sorting
{
    /// <summary>
    /// 2.2.2 - Класс-помощник по сортировке
    /// </summary>
    public static class SortingHelper
    {
        /// <summary>
        /// Сортирует книги на основе списка моделей сортировки
        /// </summary>
        /// <param name="books">Список книг</param>
        /// <param name="sortings">Список моделей сортировки</param>
        /// <returns>Отсортиованный список книг</returns>
        public static IEnumerable<BookDto> SortBooks(IEnumerable<BookDto> books, IEnumerable<SortingModel> sortings)
        {
            if (books is null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            if (sortings.NotNullAndAny())
            {
                var uniqueSortings = sortings.Distinct(s => s.ColumnName);

                var firstSorting = uniqueSortings.First();

                var orderedBooks = books.FirstOrderBy(GetBookOrderBySelector(firstSorting.ColumnName), firstSorting.Direction);

                foreach (var sorting in uniqueSortings.Skip(1))
                {
                    orderedBooks = orderedBooks.ThenOrderBy(GetBookOrderBySelector(sorting.ColumnName), sorting.Direction);
                }

                return orderedBooks;
            }

            return books;
        }

        /// <summary>
        /// Получает функцию получения свойства книги на основе названия колонки
        /// </summary>
        /// <param name="sortingColumn">Название колонки книги</param>
        /// <returns>Функция получения свойства книги</returns>
        private static Func<BookDto, string> GetBookOrderBySelector(string sortingColumn) =>
            sortingColumn switch
            {
                "title" => b => b.Title,
                "author" => b => b.Author,
                "genre" => b => b.Genre,
                _ => throw new Exception($"Название колонки сортировки {sortingColumn} не поддерживается")
            };
    }
}
