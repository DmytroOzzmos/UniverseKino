using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UniverseKino.WEB.Filters
{
    public class DefaultExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case Exception e:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.HttpContext.Response.WriteAsync(e.Message);
                    break;

                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var errorMessage = "UnhandledException";
                    await context.HttpContext.Response.WriteAsync(errorMessage);
                    break;
            }
        }
    }
}
