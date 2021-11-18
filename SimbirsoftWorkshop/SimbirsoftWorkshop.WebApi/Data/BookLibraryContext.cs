using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Data
{
    /// <summary>
    /// 1. Контекст базы данных для работы с библиотекой книг
    /// </summary>
    public sealed class BookLibraryContext : DbContext
    {
        /// <summary>
        /// 2. Набор сущностей жанров книг
        /// </summary>
        public DbSet<Genre> Genres { get; set; }
        /// <summary>
        /// 2. Набор сущностей авторов книг
        /// </summary>
        public DbSet<Author> Authors { get; set; }
        /// <summary>
        /// 2. Набор сущностей книг
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// 2. Набор сущностей пользователей
        /// </summary>
        public DbSet<Person> People { get; set; }
        /// <summary>
        /// 2. Набор сущностей учетных карточек
        /// </summary>
        public DbSet<LibraryCard> LibraryCards { get; set; }

        /// <summary>
        /// Создает новый объект контекста базы данных
        /// </summary>
        /// <param name="options">Настройки, используемые контекстом базы данных</param>
        public BookLibraryContext(DbContextOptions options)
            : base(options) { }

        /// <summary>
        /// 3. Настраивает сущности базы данных
        /// </summary>
        /// <param name="modelBuilder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureGenres(modelBuilder);
            ConfigureAuthors(modelBuilder);
            ConfigureBooks(modelBuilder);
            ConfigurePeople(modelBuilder);
            ConfigureLibraryCards(modelBuilder);
        }

        #region Configure entities

        /// <summary>
        /// 3. Настраивает сущность жанров книг
        /// </summary>
        /// <param name="builder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        private void ConfigureGenres(ModelBuilder builder)
        {
            var entity = builder.Entity<Genre>();

            entity.HasKey(g => g.Id);

            entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(64);

            entity.HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenres",
                    j => j
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_BookGenres_Books_BookId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_BookGenres_Genres_GenreId")
                        .OnDelete(DeleteBehavior.Cascade), 
                    j => j.HasData(DataSeedInitializer.BookGenres));

            entity.HasIndex(g => g.Name)
                .IsUnique();

            entity.HasData(DataSeedInitializer.Genres);
        }

        /// <summary>
        /// 3. Настраивает сущность авторов книг
        /// </summary>
        /// <param name="builder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        private void ConfigureAuthors(ModelBuilder builder)
        {
            var entity = builder.Entity<Author>();

            entity.HasKey(a => a.Id);

            entity.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(a => a.MiddleName)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasIndex(a => new { a.FirstName, a.LastName, a.MiddleName })
                .IsUnique();

            entity.HasData(DataSeedInitializer.Authors);
        }

        /// <summary>
        /// 3. Настраивает сущность книг
        /// </summary>
        /// <param name="builder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        private void ConfigureBooks(ModelBuilder builder)
        {
            var entity = builder.Entity<Book>();

            entity.HasKey(b => b.Id);

            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(b => b.Name)
                .IsUnique();

            entity.HasData(DataSeedInitializer.Books);
        }

        /// <summary>
        /// 3. Настраивает сущность пользователей
        /// </summary>
        /// <param name="builder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        private void ConfigurePeople(ModelBuilder builder)
        {
            var entity = builder.Entity<Person>();

            entity.HasKey(p => p.Id);

            entity.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(p => p.MiddleName)
                .HasMaxLength(128);

            entity.HasIndex(p => new { p.FirstName, p.LastName, p.MiddleName })
                .IsUnique();

            entity.HasData(DataSeedInitializer.People);
        }

        /// <summary>
        /// 3. Настраивает сущность учетных карточек
        /// </summary>
        /// <param name="builder">Построитель модели, предоставляющий методы для настройки сущностей базы данных</param>
        private void ConfigureLibraryCards(ModelBuilder builder)
        {
            var entity = builder.Entity<LibraryCard>();

            entity.HasKey(p => new { p.BookId, p.PersonId });

            entity.Property(lc => lc.BookReceivingDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(lc => lc.Book)
                .WithMany(b => b.LibraryCards)
                .HasForeignKey(lc => lc.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(lc => lc.Person)
                .WithMany(p => p.LibraryCards)
                .HasForeignKey(lc => lc.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(DataSeedInitializer.LibraryCards);
        }

        #endregion
    }
}
