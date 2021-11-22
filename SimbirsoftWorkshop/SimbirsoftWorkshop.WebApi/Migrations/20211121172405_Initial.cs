using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SimbirsoftWorkshop.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    BookReceivingDate = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => new { x.BookId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_LibraryCards_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryCards_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, "Джон", "Толкин", "Роналд Руэл" },
                    { 2, "Джордж", "Оруэлл", "NULL" },
                    { 3, "Джоан", "Роулинг", "Кэтлин" },
                    { 4, "Фрэнк", "Герберт", "NULL" },
                    { 5, "Льюис", "Кэрролл", "NULL" },
                    { 6, "Клайв", "Льюис", "Стейплз" },
                    { 7, "Джордж", "Мартин", "Рэймонд Ричард" },
                    { 8, "Стивен", "Кинг", "Эдвин" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 30, "Сказки народов мира" },
                    { 29, "Русские сказки" },
                    { 28, "Детская литература" },
                    { 24, "Исторические приключения" },
                    { 26, "Поэзия" },
                    { 25, "Морские приключения" },
                    { 31, "Любовные романы" },
                    { 27, "Русская поэзия" },
                    { 32, "Остросюжетные любовные романы" },
                    { 36, "Психологический детектив" },
                    { 34, "Детские детективы" },
                    { 35, "Криминальный детектив" },
                    { 23, "Приключения" },
                    { 37, "Исторический детектив" },
                    { 38, "Классический детектив" },
                    { 39, "Мистика" },
                    { 40, "Триллер" },
                    { 41, "Ужасы" },
                    { 42, "Зарубежное фэнтези" },
                    { 33, "Детективы" },
                    { 22, "Проза для детей" },
                    { 20, "Классическая проза" },
                    { 8, "Городское фэнтези" },
                    { 2, "Научная фантастика" },
                    { 3, "Космическая фантастика" },
                    { 4, "Детективная фантастика" },
                    { 5, "Детская фантастика" },
                    { 6, "Постапокалипсис" },
                    { 7, "Фэнтези" },
                    { 21, "Проза" },
                    { 9, "Стимпанк" },
                    { 1, "Фантастика" },
                    { 10, "Киберпанк" },
                    { 12, "Роман" },
                    { 13, "Повесть" },
                    { 14, "Зарубежная классика" },
                    { 15, "Историческая проза" },
                    { 16, "Русская классическая проза" },
                    { 17, "Зарубежная классическая проза" },
                    { 18, "Средневековая классическая проза" },
                    { 19, "Проза о войне" },
                    { 11, "Антиутопия" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 3, new DateTime(1987, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Майя", "Медведева", "Савельевна" },
                    { 4, new DateTime(1984, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лев", "Соловьев", "Степанович" },
                    { 1, new DateTime(1971, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Василий", "Сергеев", "Владимирович" },
                    { 2, new DateTime(1975, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрей", "Панфилов", "Артёмович" },
                    { 5, new DateTime(1963, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Макар", "Зайцев", "Олегович" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Властелин Колец" },
                    { 27, 5, "Алиса в Стране чудес" },
                    { 28, 5, "Алиса в Зазеркалье" },
                    { 29, 5, "Охота на Снарка" },
                    { 30, 6, "Лев, Колдунья и Платяной шкаф" },
                    { 31, 6, "Принц Каспиан" },
                    { 32, 6, "Покоритель Зари, или Плавание на край света" },
                    { 33, 6, "Серебряное кресло" },
                    { 34, 6, "Конь и его мальчик" },
                    { 35, 6, "Племянник чародея" },
                    { 26, 4, "Капитул Дюны" },
                    { 36, 6, "Последняя битва" },
                    { 38, 7, "Битва королей" },
                    { 39, 7, "Буря мечей" },
                    { 40, 7, "Пир стервятников" },
                    { 41, 7, "Танец с драконами" },
                    { 42, 8, "Оно" },
                    { 43, 8, "Сияние" },
                    { 44, 8, "Лавка дурных снов" },
                    { 45, 8, "Доктор Сон" },
                    { 46, 8, "Мизери" },
                    { 37, 7, "Игра престолов" },
                    { 25, 4, "Еретики Дюны" },
                    { 24, 4, "Бог-Император Дюны" },
                    { 23, 4, "Дети Дюны" },
                    { 2, 1, "Хоббит, или Туда и Обратно" },
                    { 3, 1, "Хоббит" },
                    { 4, 1, "Возвращение Короля" },
                    { 5, 1, "Сильмариллион" },
                    { 6, 2, "1984" },
                    { 7, 2, "Скотный двор" },
                    { 8, 2, "Дочь священника" },
                    { 9, 2, "Да здравствует фикус!" },
                    { 10, 2, "Дни в Бирме" },
                    { 11, 3, "Гарри Поттер и философский камень" },
                    { 12, 3, "Гарри Поттер и Тайная комната" },
                    { 13, 3, "Гарри Поттер и узник Азкабана" },
                    { 14, 3, "Гарри Поттер и Кубок огня" },
                    { 15, 3, "Гарри Поттер и Орден Феникса" },
                    { 16, 3, "Гарри Поттер и принц-полукровка" },
                    { 17, 3, "Гарри Поттер и Дары Смерти" },
                    { 18, 3, "Сказки барда Бидля" },
                    { 19, 3, "Фантастические твари и где они обитают" },
                    { 20, 3, "Фантастические твари: Преступления Грин-де-Вальда" },
                    { 21, 4, "Дюна" },
                    { 22, 4, "Мессия Дюны" },
                    { 47, 8, "Зелёная миля" },
                    { 48, 8, "Ловец снов" }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 33, 23 },
                    { 33, 42 },
                    { 33, 7 },
                    { 32, 23 },
                    { 32, 42 },
                    { 32, 7 },
                    { 31, 23 },
                    { 31, 42 },
                    { 31, 7 },
                    { 30, 23 },
                    { 30, 42 },
                    { 30, 7 },
                    { 29, 23 },
                    { 29, 28 },
                    { 29, 30 },
                    { 28, 23 },
                    { 28, 28 },
                    { 28, 30 },
                    { 27, 23 },
                    { 27, 28 },
                    { 27, 30 },
                    { 26, 3 },
                    { 26, 1 },
                    { 25, 3 },
                    { 25, 1 },
                    { 34, 7 },
                    { 34, 42 },
                    { 34, 23 },
                    { 35, 7 },
                    { 47, 39 },
                    { 46, 41 },
                    { 46, 40 },
                    { 45, 40 },
                    { 45, 39 },
                    { 44, 41 },
                    { 44, 39 },
                    { 43, 41 },
                    { 43, 39 },
                    { 42, 41 },
                    { 42, 39 },
                    { 41, 42 },
                    { 47, 40 },
                    { 41, 7 },
                    { 40, 7 },
                    { 39, 42 },
                    { 39, 7 },
                    { 38, 42 },
                    { 38, 7 },
                    { 37, 42 },
                    { 37, 7 },
                    { 36, 23 },
                    { 36, 42 },
                    { 36, 7 },
                    { 35, 23 },
                    { 35, 42 },
                    { 40, 42 },
                    { 24, 1 },
                    { 24, 3 },
                    { 23, 1 },
                    { 13, 28 },
                    { 13, 42 },
                    { 13, 7 },
                    { 12, 28 },
                    { 12, 42 },
                    { 12, 7 },
                    { 11, 28 },
                    { 11, 42 },
                    { 11, 7 },
                    { 10, 20 },
                    { 10, 17 },
                    { 10, 14 },
                    { 23, 3 },
                    { 9, 17 },
                    { 8, 17 },
                    { 8, 14 },
                    { 7, 20 },
                    { 7, 17 },
                    { 7, 14 },
                    { 6, 11 },
                    { 5, 7 },
                    { 4, 7 },
                    { 3, 23 },
                    { 3, 7 },
                    { 2, 23 },
                    { 2, 7 },
                    { 9, 14 },
                    { 14, 42 },
                    { 14, 7 },
                    { 18, 42 },
                    { 22, 3 },
                    { 22, 1 },
                    { 21, 3 },
                    { 21, 1 },
                    { 20, 3 },
                    { 20, 1 },
                    { 19, 28 },
                    { 19, 42 },
                    { 19, 7 },
                    { 18, 28 },
                    { 14, 28 },
                    { 18, 7 },
                    { 17, 28 },
                    { 47, 41 },
                    { 16, 7 },
                    { 17, 42 },
                    { 17, 7 },
                    { 16, 28 },
                    { 15, 7 },
                    { 16, 42 },
                    { 15, 42 },
                    { 15, 28 }
                });

            migrationBuilder.InsertData(
                table: "LibraryCards",
                columns: new[] { "BookId", "PersonId", "BookReceivingDate" },
                values: new object[,]
                {
                    { 14, 2, new DateTimeOffset(new DateTime(2022, 11, 15, 8, 28, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 21, 1, new DateTimeOffset(new DateTime(2022, 10, 20, 16, 27, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 10, 2, new DateTimeOffset(new DateTime(2022, 11, 5, 22, 46, 49, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 15, 2, new DateTimeOffset(new DateTime(2022, 10, 28, 5, 11, 12, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 29, 4, new DateTimeOffset(new DateTime(2021, 10, 16, 0, 39, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 27, 3, new DateTimeOffset(new DateTime(2022, 10, 18, 4, 30, 48, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 7, 4, new DateTimeOffset(new DateTime(2022, 11, 5, 16, 8, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 28, 4, new DateTimeOffset(new DateTime(2022, 11, 9, 0, 47, 41, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 12, 5, new DateTimeOffset(new DateTime(2022, 10, 19, 22, 20, 45, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 33, 2, new DateTimeOffset(new DateTime(2022, 11, 6, 10, 32, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FirstName_LastName_MiddleName",
                table: "Authors",
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Name",
                table: "Books",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_PersonId",
                table: "LibraryCards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FirstName_LastName_MiddleName",
                table: "People",
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
