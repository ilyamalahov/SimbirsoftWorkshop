using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SimbirsoftWorkshop.WebApi.Swagger
{
    /// <summary>
    /// Фильтр Swagger, добавляющий заголовок базовой авторизации (username:password) в каждый отправляемый запрос
    /// </summary>
    public class AddBasicAuthorizationHeaderFilter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = operation.Parameters ?? new List<OpenApiParameter>();

            parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                Description = "Basic authorization (username:password)",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("Basic ")
                }
            });
        }
    }
}
