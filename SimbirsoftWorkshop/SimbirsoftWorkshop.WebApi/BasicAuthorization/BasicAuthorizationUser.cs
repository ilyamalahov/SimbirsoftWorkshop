using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftWorkshop.WebApi.BasicAuthorization
{
    /// <summary>
    /// Пользователь базовой авторизации
    /// </summary>
    public class BasicAuthorizationUser
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Проверяет, что пользователь и пароль не пустые
        /// </summary>
        public bool IsNotNull => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        /// <summary>
        /// Создает пользователя, используя парсинг из строки формата "пользователь:пароль"
        /// </summary>
        /// <param name="input">Строка формата "пользователь:пароль"</param>
        /// <returns>Созданный пользователь базовой авторизации</returns>
        public static BasicAuthorizationUser Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"\"{nameof(input)}\" не может быть неопределенным или пустым.", nameof(input));
            }

            var chunks = input.Split(':', 2, StringSplitOptions.None);

            return
                chunks.Length == 2 ?
                new BasicAuthorizationUser
                {
                    Username = chunks[0],
                    Password = chunks[1]
                } :
                null;
        }

        /// <summary>
        /// Проверяет правильность имени прользователя и пароля
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Результат проверки</returns>
        public bool IsValid(string username, string password)
        {
            return IsNotNull && Username == username && password == Password;
        }
    }
}
