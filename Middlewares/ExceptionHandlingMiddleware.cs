using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CoreModelSeperation.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleException(context, ex, StatusCodes.Status401Unauthorized);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleException(context, ex, StatusCodes.Status404NotFound);
            }
            catch (ArgumentException ex)
            {
                await HandleException(context, ex, StatusCodes.Status400BadRequest);
            }
            catch (InvalidOperationException ex)
            {
                await HandleException(context, ex, StatusCodes.Status409Conflict);
            }
            catch (OperationCanceledException ex)
            {
                await HandleException(context, ex, StatusCodes.Status408RequestTimeout);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task HandleException(
            HttpContext context,
            Exception exception,
            int statusCode)
        {
            _logger.LogError(exception, "Unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                statusCode,
                message = exception.Message,
                traceId = context.TraceIdentifier
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}