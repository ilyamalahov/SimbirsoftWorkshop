using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SimbirsoftWorkshop.WebApi.RequestResponseLogging
{
    /// <summary>
    /// Метод расширения построителя конвеера запроса для обработки логгирования HTTP-запросов и ответов
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Добавляет компонент логгирования HTTP-запросов и ответов в конвеер запросов
        /// </summary>
        /// <param name="builder">Построитель конвеера запроса</param>
        /// <returns>Построитель конвеера запроса</returns>
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
