using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SimbirsoftWorkshop.WebApi
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Стартовая точка входа в программу
        /// </summary>
        /// <param name="args">Аргументы, передаваемые в программу при запуске</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Возвращает созданный построитель с настроееным хостом
        /// </summary>
        /// <param name="args">Аргументы, передаваемые в программу при запуске</param>
        /// <returns>Построитель хоста</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
