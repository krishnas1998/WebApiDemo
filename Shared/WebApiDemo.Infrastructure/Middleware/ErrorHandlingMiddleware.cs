using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApiDemo.Infrastructure.Exceptions;
using WebApiDemo.Infrastructure.Models;
using WebApiDemo.Infrastructure.Properties;

namespace WebApiDemo.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch (ResourceNotFoundException exception)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            //    await HandleExceptionAsync(context, exception);
            //}
            catch (ResourceAlreadyExistsException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await HandleExceptionAsync(context, exception);
            }
            catch (Exception exception)
            {
                exception.Source ??= Resources.UnhandledException;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(new ResultData(exception.Message, exception.Source));

            _logger.LogError(exception, Resources.InternalErrorMessage, result);
            context.Response.ContentType = Resources.JsonContentType;
            return context.Response.WriteAsync(result);
        }
    }
}
