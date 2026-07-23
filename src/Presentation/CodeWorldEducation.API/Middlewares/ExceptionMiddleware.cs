using System.Net;
using System.Text.Json;

namespace CodeWorldEducation.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse();

            switch (exception)
            {
                case ArgumentException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Message = exception.Message;

                    _logger.LogWarning(
                        "Validation error. " +
                        "Path: {Path} | Message: {Message} | Time: {Time}",
                        context.Request.Path,
                        exception.Message,
                        DateTime.UtcNow);
                    break;

                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = exception.Message;

                    _logger.LogWarning("Resource not found. " +
                        "Path: {Path} | Message: {Message} | Time: {Time}",
                        context.Request.Path,
                        exception.Message,
                        DateTime.UtcNow);
                    break;

                case InvalidOperationException:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.StatusCode = StatusCodes.Status409Conflict;
                    response.Message = exception.Message;

                    _logger.LogWarning("Conflict error. " +
                        "Path: {Path} | Message: {Message} | Time: {Time}",
                        context.Request.Path,
                        exception.Message,
                        DateTime.UtcNow);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Message = "An unexpected error occurred.";

                    _logger.LogError(exception,
                        "Unexpected error occurred. " +
                        "Path: {Path} | Message: {Message} | " +
                        "StackTrace: {StackTrace} | Time: {Time}",
                        context.Request.Path,
                        exception.Message,
                        exception.StackTrace,
                        DateTime.UtcNow);
                    break;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
