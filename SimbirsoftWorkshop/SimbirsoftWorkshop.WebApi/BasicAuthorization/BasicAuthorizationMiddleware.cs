using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimbirsoftWorkshop.WebApi.BasicAuthorization
{
    /// <summary>
    /// 2.2.4 - Компонент обработки базовой авторизации (Basic username:password) в конвеере запросов
    /// </summary>
    public class BasicAuthorizationMiddleware
    {
        private const string HeaderPrefix = "Basic";

        /// <summary>
        /// Делегат перехода к следующему компоненту конвеера запроса
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Создает новый объект промежуточного слоя
        /// </summary>
        /// <param name="next">Делегат перехода к следующему компоненту конвеера запроса</param>
        public BasicAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Вызывает обработку запроса 
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        /// <returns>Задача обработки запроса</returns>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Authorization", out var header))
            {
                await SendUnauthorizedResponse(context, "Отсутствует заголовок Authorization");

                return;
            }

            var headerValue = header.First();

            if (string.IsNullOrEmpty(headerValue))
            {
                await SendUnauthorizedResponse(context, "Пустое содержимое заголовка Authorization");

                return;
            }

            if (!headerValue.StartsWith(HeaderPrefix))
            {
                await SendUnauthorizedResponse(context, "Содержимое заголовка Authorization должно начинаться с Basic");

                return;
            }

            var pair = headerValue.Substring(HeaderPrefix.Length).TrimStart();

            var basicAuthorizationUser = BasicAuthorizationUser.Parse(pair);

            if (basicAuthorizationUser == null)
            {
                await SendUnauthorizedResponse(context, "Не удалось распарсить пару (пользователь:пароль) в заголовке Authorization");

                return;
            }

            if (!basicAuthorizationUser.IsValid("admin", "admin"))
            {
                await SendUnauthorizedResponse(context, "Неверное имя пользователя или пароль");

                return;
            }

            await next(context);
        }

        /// <summary>
        /// Отправляет клиенту ответ 401 (Unauthorized) с текстом ошибки
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        /// <param name="errorMessage">Текст ошибки</param>
        /// <returns>Задача отправки ответа клиенту</returns>
        public async Task SendUnauthorizedResponse(HttpContext context, string errorMessage)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = MediaTypeNames.Text.Plain;
            await context.Response.WriteAsync(errorMessage);
        }
    }
}
