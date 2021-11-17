using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimbirsoftWorkshop.WebApi.Data
{
    /// <summary>
    /// 1. Контекст базы данных для работы с библиотекой книг
    /// </summary>
    public sealed class BookLibraryContext : DbContext
    {
        /// <summary>
        /// Создает новый объект контекста базы данных
        /// </summary>
        /// <param name="options">Настройки, используемые контекстом базы данных</param>
        public BookLibraryContext(DbContextOptions options)
            : base(options) { }
    }
}
