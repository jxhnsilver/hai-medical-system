using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Hai.MedicalSystem.Api.Common.Exceptions
{
    public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context, Exception exception, CancellationToken ct)
        {
            var (status, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
                _ => (StatusCodes.Status500InternalServerError, "Internal server error")
            };

            if (status == StatusCodes.Status500InternalServerError)
            {
                logger.LogError(
                    exception,
                    "Unhandled exception while processing {HttpMethod} {RequestPath}. " +
                    "TraceId: {TraceId}. ExceptionType: {ExceptionType}",
                    context.Request.Method,
                    context.Request.Path,
                    context.TraceIdentifier,
                    exception.GetType().FullName);
            }

            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = status == StatusCodes.Status500InternalServerError
                    ? null
                    : exception.Message,
                Instance = $"{context.Request.Method} {context.Request.Path}",
            }, ct);

            return true;
        }
    }
}
