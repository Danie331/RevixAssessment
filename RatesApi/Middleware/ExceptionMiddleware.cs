using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RatesApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Exception message obfuscated for security reasons
                var friendlyErrorMessage = "An unspecified error occurred - please contact support for help";
                await HandleExceptionAsync(httpContext, friendlyErrorMessage);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string responseMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                context.Response.StatusCode,
                Message = $"Internal Server Error: {responseMessage}"
            }));
        }
    }
}
