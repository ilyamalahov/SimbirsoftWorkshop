using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SimbirsoftWorkshop.WebApi.BasicAuthorization
{
    /// <summary>
    /// Метод расширения построителя конвеера запроса для обработки базовой авторизации
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Добавляет компонент обработки базовой авторизации в конвеер запросов
        /// </summary>
        /// <param name="builder">Построитель конвеера запроса</param>
        /// <returns>Построитель конвеера запроса</returns>
        public static IApplicationBuilder UseBasicAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthorizationMiddleware>();
        }
    }
}
