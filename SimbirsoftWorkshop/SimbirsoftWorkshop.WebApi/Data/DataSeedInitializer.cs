using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Data
{
    public static class DataSeedInitializer
    {
        private readonly static TimeSpan timezoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);

        public static IEnumerable<Genre> Genres { get; }
        public static IEnumerable<Author> Authors { get; }
        public static IEnumerable<Book> Books { get; }
        public static IEnumerable<Person> People { get; }
        public static IEnumerable<LibraryCard> LibraryCards { get; }
        public static IEnumerable<object> BookGenres { get; }

        static DataSeedInitializer()
        {
            Genres = GetInitGenres();
            Authors = GetInitAuthors();
            Books = GetInitBooks();
            People = GetInitPeople();
            LibraryCards = GetInitLibraryCards();
            BookGenres = GetBookGenres();
        }

        private static IEnumerable<Genre> GetInitGenres()
        {
            return new List<Genre>
            {
                new Genre { Id = 1, Name = "Фантастика" },
                new Genre { Id = 2, Name = "Научная фантастика" },
                new Genre { Id = 3, Name = "Космическая фантастика" },
                new Genre { Id = 4, Name = "Детективная фантастика" },
                new Genre { Id = 5, Name = "Детская фантастика" },
                new Genre { Id = 6, Name = "Постапокалипсис" },
                new Genre { Id = 7, Name = "Фэнтези" },
                new Genre { Id = 8, Name = "Городское фэнтези" },
                new Genre { Id = 9, Name = "Стимпанк" },
                new Genre { Id = 10, Name = "Киберпанк" },
                new Genre { Id = 11, Name = "Антиутопия" },
                new Genre { Id = 12, Name = "Роман" },
                new Genre { Id = 13, Name = "Повесть" },
                new Genre { Id = 14, Name = "Зарубежная классика" },
                new Genre { Id = 15, Name = "Историческая проза" },
                new Genre { Id = 16, Name = "Русская классическая проза" },
                new Genre { Id = 17, Name = "Зарубежная классическая проза" },
                new Genre { Id = 18, Name = "Средневековая классическая проза" },
                new Genre { Id = 19, Name = "Проза о войне" },
                new Genre { Id = 20, Name = "Классическая проза" },
                new Genre { Id = 21, Name = "Проза" },
                new Genre { Id = 22, Name = "Проза для детей" },
                new Genre { Id = 23, Name = "Приключения" },
                new Genre { Id = 24, Name = "Исторические приключения" },
                new Genre { Id = 25, Name = "Морские приключения" },
                new Genre { Id = 26, Name = "Поэзия" },
                new Genre { Id = 27, Name = "Русская поэзия" },
                new Genre { Id = 28, Name = "Детская литература" },
                new Genre { Id = 29, Name = "Русские сказки" },
                new Genre { Id = 30, Name = "Сказки народов мира" },
                new Genre { Id = 31, Name = "Любовные романы" },
                new Genre { Id = 32, Name = "Остросюжетные любовные романы" },
                new Genre { Id = 33, Name = "Детективы" },
                new Genre { Id = 34, Name = "Детские детективы" },
                new Genre { Id = 35, Name = "Криминальный детектив" },
                new Genre { Id = 36, Name = "Психологический детектив" },
                new Genre { Id = 37, Name = "Исторический детектив" },
                new Genre { Id = 38, Name = "Классический детектив" },
                new Genre { Id = 39, Name = "Мистика" },
                new Genre { Id = 40, Name = "Триллер" },
                new Genre { Id = 41, Name = "Ужасы" },
                new Genre { Id = 42, Name = "Зарубежное фэнтези" }
            };
        }

        private static IEnumerable<Author> GetInitAuthors()
        {
            return new List<Author>
            {
                new Author { Id = 1, FirstName = "Джон", MiddleName = "Роналд Руэл", LastName = "Толкин" },
                new Author { Id = 2, FirstName = "Джордж", MiddleName = "NULL", LastName = "Оруэлл" },
                new Author { Id = 3, FirstName = "Джоан", MiddleName = "Кэтлин", LastName = "Роулинг" },
                new Author { Id = 4, FirstName = "Фрэнк", MiddleName = "NULL", LastName = "Герберт" },
                new Author { Id = 5, FirstName = "Льюис", MiddleName = "NULL", LastName = "Кэрролл" },
                new Author { Id = 6, FirstName = "Клайв", MiddleName = "Стейплз", LastName = "Льюис" },
                new Author { Id = 7, FirstName = "Джордж", MiddleName = "Рэймонд Ричард", LastName = "Мартин" },
                new Author { Id = 8, FirstName = "Стивен", MiddleName = "Эдвин", LastName = "Кинг" }
            };
        }

        private static IEnumerable<Book> GetInitBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Name = "Властелин Колец", AuthorId = 1 },
                new Book { Id = 2, Name = "Хоббит, или Туда и Обратно", AuthorId = 1 },
                new Book { Id = 3, Name = "Хоббит", AuthorId = 1 },
                new Book { Id = 4, Name = "Возвращение Короля", AuthorId = 1 },
                new Book { Id = 5, Name = "Сильмариллион", AuthorId = 1 },
                new Book { Id = 6, Name = "1984", AuthorId = 2 },
                new Book { Id = 7, Name = "Скотный двор", AuthorId = 2 },
                new Book { Id = 8, Name = "Дочь священника", AuthorId = 2 },
                new Book { Id = 9, Name = "Да здравствует фикус!", AuthorId = 2 },
                new Book { Id = 10, Name = "Дни в Бирме", AuthorId = 2 },
                new Book { Id = 11, Name = "Гарри Поттер и философский камень", AuthorId = 3 },
                new Book { Id = 12, Name = "Гарри Поттер и Тайная комната", AuthorId = 3 },
                new Book { Id = 13, Name = "Гарри Поттер и узник Азкабана", AuthorId = 3 },
                new Book { Id = 14, Name = "Гарри Поттер и Кубок огня", AuthorId = 3 },
                new Book { Id = 15, Name = "Гарри Поттер и Орден Феникса", AuthorId = 3 },
                new Book { Id = 16, Name = "Гарри Поттер и принц-полукровка", AuthorId = 3 },
                new Book { Id = 17, Name = "Гарри Поттер и Дары Смерти", AuthorId = 3 },
                new Book { Id = 18, Name = "Сказки барда Бидля", AuthorId = 3 },
                new Book { Id = 19, Name = "Фантастические твари и где они обитают", AuthorId = 3 },
                new Book { Id = 20, Name = "Фантастические твари: Преступления Грин-де-Вальда", AuthorId = 3 },
                new Book { Id = 21, Name = "Дюна", AuthorId = 4 },
                new Book { Id = 22, Name = "Мессия Дюны", AuthorId = 4 },
                new Book { Id = 23, Name = "Дети Дюны", AuthorId = 4 },
                new Book { Id = 24, Name = "Бог-Император Дюны", AuthorId = 4 },
                new Book { Id = 25, Name = "Еретики Дюны", AuthorId = 4 },
                new Book { Id = 26, Name = "Капитул Дюны", AuthorId = 4 },
                new Book { Id = 27, Name = "Алиса в Стране чудес", AuthorId = 5 },
                new Book { Id = 28, Name = "Алиса в Зазеркалье", AuthorId = 5 },
                new Book { Id = 29, Name = "Охота на Снарка", AuthorId = 5 },
                new Book { Id = 30, Name = "Лев, Колдунья и Платяной шкаф", AuthorId = 6 },
                new Book { Id = 31, Name = "Принц Каспиан", AuthorId = 6 },
                new Book { Id = 32, Name = "Покоритель Зари, или Плавание на край света", AuthorId = 6 },
                new Book { Id = 33, Name = "Серебряное кресло", AuthorId = 6 },
                new Book { Id = 34, Name = "Конь и его мальчик", AuthorId = 6 },
                new Book { Id = 35, Name = "Племянник чародея", AuthorId = 6 },
                new Book { Id = 36, Name = "Последняя битва", AuthorId = 6 },
                new Book { Id = 37, Name = "Игра престолов", AuthorId = 7 },
                new Book { Id = 38, Name = "Битва королей", AuthorId = 7 },
                new Book { Id = 39, Name = "Буря мечей", AuthorId = 7 },
                new Book { Id = 40, Name = "Пир стервятников", AuthorId = 7 },
                new Book { Id = 41, Name = "Танец с драконами", AuthorId = 7 },
                new Book { Id = 42, Name = "Оно", AuthorId = 8 },
                new Book { Id = 43, Name = "Сияние", AuthorId = 8 },
                new Book { Id = 44, Name = "Лавка дурных снов", AuthorId = 8 },
                new Book { Id = 45, Name = "Доктор Сон", AuthorId = 8 },
                new Book { Id = 46, Name = "Мизери", AuthorId = 8 },
                new Book { Id = 47, Name = "Зелёная миля", AuthorId = 8 },
                new Book { Id = 48, Name = "Ловец снов", AuthorId = 8 }
            };
        }

        private static IEnumerable<Person> GetInitPeople()
        {
            return new List<Person>
            {
                new Person { Id = 1, LastName = "Сергеев", FirstName = "Василий", MiddleName = "Владимирович", Birthday = new DateTime(1971, 12, 28) },
                new Person { Id = 2, LastName = "Панфилов", FirstName = "Андрей", MiddleName = "Артёмович", Birthday = new DateTime(1975, 04, 30) },
                new Person { Id = 3, LastName = "Медведева", FirstName = "Майя", MiddleName = "Савельевна", Birthday = new DateTime(1987, 11, 13) },
                new Person { Id = 4, LastName = "Соловьев", FirstName = "Лев", MiddleName = "Степанович", Birthday = new DateTime(1984, 04, 28) },
                new Person { Id = 5, LastName = "Зайцев", FirstName = "Макар", MiddleName = "Олегович", Birthday = new DateTime(1963, 02, 28) }
            };
        }

        private static IEnumerable<LibraryCard> GetInitLibraryCards()
        {
            return new List<LibraryCard>
            {
                new LibraryCard { BookId = 33, PersonId = 2, BookReceivingDate = new DateTimeOffset(2022, 11, 06, 10, 32, 40, timezoneOffset) },
                new LibraryCard { BookId = 15, PersonId = 2, BookReceivingDate = new DateTimeOffset(2022, 10, 28, 05, 11, 12, timezoneOffset) },
                new LibraryCard { BookId = 29, PersonId = 4, BookReceivingDate = new DateTimeOffset(2021, 10, 16, 00, 39, 24, timezoneOffset) },
                new LibraryCard { BookId = 14, PersonId = 2, BookReceivingDate = new DateTimeOffset(2022, 11, 15, 08, 28, 19, timezoneOffset) },
                new LibraryCard { BookId = 10, PersonId = 2, BookReceivingDate = new DateTimeOffset(2022, 11, 05, 22, 46, 49, timezoneOffset) },
                new LibraryCard { BookId = 21, PersonId = 1, BookReceivingDate = new DateTimeOffset(2022, 10, 20, 16, 27, 14, timezoneOffset) },
                new LibraryCard { BookId = 28, PersonId = 4, BookReceivingDate = new DateTimeOffset(2022, 11, 09, 00, 47, 41, timezoneOffset) },
                new LibraryCard { BookId = 7, PersonId = 4, BookReceivingDate = new DateTimeOffset(2022, 11, 05, 16, 08, 01, timezoneOffset) },
                new LibraryCard { BookId = 27, PersonId = 3, BookReceivingDate = new DateTimeOffset(2022, 10, 18, 04, 30, 48, timezoneOffset) },
                new LibraryCard { BookId = 12, PersonId = 5, BookReceivingDate = new DateTimeOffset(2022, 10, 19, 22, 20, 45, timezoneOffset) }
            };
        }

        private static IEnumerable<object> GetBookGenres()
        {
            return new[] 
            {
                new { BookId = 1, GenreId = 7 },
                new { BookId = 2, GenreId = 7 },
                new { BookId = 2, GenreId = 23 },
                new { BookId = 3, GenreId = 7 },
                new { BookId = 3, GenreId = 23 },
                new { BookId = 4, GenreId = 7 },
                new { BookId = 5, GenreId = 7 },
                new { BookId = 6, GenreId = 11 },
                new { BookId = 7, GenreId = 14 },
                new { BookId = 7, GenreId = 17 },
                new { BookId = 7, GenreId = 20 },
                new { BookId = 8, GenreId = 14 },
                new { BookId = 8, GenreId = 17 },
                new { BookId = 9, GenreId = 14 },
                new { BookId = 9, GenreId = 17 },
                new { BookId = 10, GenreId = 14 },
                new { BookId = 10, GenreId = 17 },
                new { BookId = 10, GenreId = 20 },
                new { BookId = 11, GenreId = 7 },
                new { BookId = 11, GenreId = 42 },
                new { BookId = 11, GenreId = 28 },
                new { BookId = 12, GenreId = 7 },
                new { BookId = 12, GenreId = 42 },
                new { BookId = 12, GenreId = 28 },
                new { BookId = 13, GenreId = 7 },
                new { BookId = 13, GenreId = 42 },
                new { BookId = 13, GenreId = 28 },
                new { BookId = 14, GenreId = 7 },
                new { BookId = 14, GenreId = 42 },
                new { BookId = 14, GenreId = 28 },
                new { BookId = 15, GenreId = 7 },
                new { BookId = 15, GenreId = 42 },
                new { BookId = 15, GenreId = 28 },
                new { BookId = 16, GenreId = 7 },
                new { BookId = 16, GenreId = 42 },
                new { BookId = 16, GenreId = 28 },
                new { BookId = 17, GenreId = 7 },
                new { BookId = 17, GenreId = 42 },
                new { BookId = 17, GenreId = 28 },
                new { BookId = 18, GenreId = 7 },
                new { BookId = 18, GenreId = 42 },
                new { BookId = 18, GenreId = 28 },
                new { BookId = 19, GenreId = 7 },
                new { BookId = 19, GenreId = 42 },
                new { BookId = 19, GenreId = 28 },
                new { BookId = 20, GenreId = 1 },
                new { BookId = 20, GenreId = 3 },
                new { BookId = 21, GenreId = 1 },
                new { BookId = 21, GenreId = 3 },
                new { BookId = 22, GenreId = 1 },
                new { BookId = 22, GenreId = 3 },
                new { BookId = 23, GenreId = 1 },
                new { BookId = 23, GenreId = 3 },
                new { BookId = 24, GenreId = 1 },
                new { BookId = 24, GenreId = 3 },
                new { BookId = 25, GenreId = 1 },
                new { BookId = 25, GenreId = 3 },
                new { BookId = 26, GenreId = 1 },
                new { BookId = 26, GenreId = 3 },
                new { BookId = 27, GenreId = 30 },
                new { BookId = 27, GenreId = 28 },
                new { BookId = 27, GenreId = 23 },
                new { BookId = 28, GenreId = 30 },
                new { BookId = 28, GenreId = 28 },
                new { BookId = 28, GenreId = 23 },
                new { BookId = 29, GenreId = 30 },
                new { BookId = 29, GenreId = 28 },
                new { BookId = 29, GenreId = 23 },
                new { BookId = 30, GenreId = 7 },
                new { BookId = 30, GenreId = 42 },
                new { BookId = 30, GenreId = 23 },
                new { BookId = 31, GenreId = 7 },
                new { BookId = 31, GenreId = 42 },
                new { BookId = 31, GenreId = 23 },
                new { BookId = 32, GenreId = 7 },
                new { BookId = 32, GenreId = 42 },
                new { BookId = 32, GenreId = 23 },
                new { BookId = 33, GenreId = 7 },
                new { BookId = 33, GenreId = 42 },
                new { BookId = 33, GenreId = 23 },
                new { BookId = 34, GenreId = 7 },
                new { BookId = 34, GenreId = 42 },
                new { BookId = 34, GenreId = 23 },
                new { BookId = 35, GenreId = 7 },
                new { BookId = 35, GenreId = 42 },
                new { BookId = 35, GenreId = 23 },
                new { BookId = 36, GenreId = 7 },
                new { BookId = 36, GenreId = 42 },
                new { BookId = 36, GenreId = 23 },
                new { BookId = 37, GenreId = 7 },
                new { BookId = 37, GenreId = 42 },
                new { BookId = 38, GenreId = 7 },
                new { BookId = 38, GenreId = 42 },
                new { BookId = 39, GenreId = 7 },
                new { BookId = 39, GenreId = 42 },
                new { BookId = 40, GenreId = 7 },
                new { BookId = 40, GenreId = 42 },
                new { BookId = 41, GenreId = 7 },
                new { BookId = 41, GenreId = 42 },
                new { BookId = 42, GenreId = 39 },
                new { BookId = 42, GenreId = 41 },
                new { BookId = 43, GenreId = 39 },
                new { BookId = 43, GenreId = 41 },
                new { BookId = 44, GenreId = 39 },
                new { BookId = 44, GenreId = 41 },
                new { BookId = 45, GenreId = 39 },
                new { BookId = 45, GenreId = 40 },
                new { BookId = 46, GenreId = 40 },
                new { BookId = 46, GenreId = 41 },
                new { BookId = 47, GenreId = 39 },
                new { BookId = 47, GenreId = 40 },
                new { BookId = 47, GenreId = 41 }
            };
        }
    }
}
