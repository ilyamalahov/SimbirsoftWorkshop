using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimbirsoftWorkshop.WebApi.BasicAuthorization;
using SimbirsoftWorkshop.WebApi.Data;
using SimbirsoftWorkshop.WebApi.Repositories;
using SimbirsoftWorkshop.WebApi.RequestResponseLogging;

namespace SimbirsoftWorkshop.WebApi
{
    /// <summary>
    /// ��������� ����� ��� ��������� ������������ � �������� ��������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ������� ����� ������ ��������� ������������ � �������� ��������
        /// </summary>
        /// <param name="configuration">������ ������������</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ������ ������������
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����������� ����������� (�������) � ���������� ������������
        /// </summary>
        /// <param name="services">��������� ������������ (��������)</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 4. ��������� ������ ����������� � ���� ������ �� ������������
            var connectionString = Configuration.GetConnectionString("BookLibraryConnection");

            services.AddDbContext<BookLibraryContext>(options => options.UseMySQL(connectionString));

            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddTransient<IPeopleRepository, PeopleRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Books library Web API",
                    Description = "Web API ���������� ���� �� ���������� Simbirsoft"
                });

                var xmlFileName = string.Concat(Assembly.GetExecutingAssembly().GetName().Name, ".xml");
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });

            services.AddControllers();
        }

        /// <summary>
        /// ����������� ������� ��������
        /// </summary>
        /// <param name="app">����������� �������� ��������</param>
        /// <param name="env">����� ���������</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestResponseLogging();

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error/dev");
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Books library Web API v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseBasicAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
