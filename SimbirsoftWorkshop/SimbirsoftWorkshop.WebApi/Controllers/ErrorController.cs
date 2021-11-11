using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace SimbirsoftWorkshop.WebApi.Controllers
{
    [Route("api/error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ErrorController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet, HttpPost, HttpPut, HttpDelete]
        [Route("/error/dev")]
        public IActionResult ErrorDevelopment()
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException("Разрешен вызов только в окружении разработки");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error")]
        [HttpGet, HttpPost, HttpPut, HttpDelete]
        public IActionResult Error() => Problem();
    }
}
