using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;
using UniverseKino.Services.Exceptions;

namespace UniverseKino.WEB.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case InvalidAuthenticateException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = e.Message;
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }

                case EntityIsNotExistException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = e.Message;
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }

                case EntityAlreadyExistsException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = e.Message;
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }

                case InvalidScheduledException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = e.Message;
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }

                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = "UnhandledException";
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }
        }
    }
}
