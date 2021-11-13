using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimbirsoftWorkshop.WebApi.RequestResponseLogging
{
    /// <summary>
    /// 2.2.3 - Компонент логгирования HTTP-запросов и ответов в конвеере запросов
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        /// <summary>
        /// Делегат перехода к следующему компоненту конвеера запроса
        /// </summary>
        private readonly RequestDelegate next;
        /// <summary>
        /// Логгер
        /// </summary>
        private readonly ILogger<RequestResponseLoggingMiddleware> logger;

        /// <summary>
        /// Создает новый объект компонента логгирования HTTP-запросов и ответов
        /// </summary>
        /// <param name="next">Делегат перехода к следующему компоненту конвеера запроса</param>
        /// <param name="logger">Логгер</param>
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Вызывает обработку запроса 
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        /// <returns>Задача обработки запроса</returns>
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            try
            {
                logger.LogInformation("Старт запроса в {RequestStartDate} ({Method}, {Path})", DateTime.Now, request.Method, request.Path);

                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception,
                    "Возникла ошибка при отправке запроса в {RequestExceptionDate} ({Method}, {Path})",
                    DateTime.Now,
                    request.Method,
                    request.Path);

                throw;
            }
            finally
            {
                logger.LogInformation(
                    "Запрос завершен в {RequestExceptionDate} ({Method}, {Path}, {StatusCode})",
                    DateTime.Now,
                    request.Method,
                    request.Path,
                    context.Response.StatusCode);
            }
        }
    }
}
