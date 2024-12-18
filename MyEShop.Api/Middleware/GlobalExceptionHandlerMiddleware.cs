namespace MyEShop.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    #region Constructor

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    #endregion

    #region Handle Error

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (Exception ex)
        {
            await LogExceptionAsync(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    #endregion

    #region Log Errors

    private async Task LogExceptionAsync(HttpContext context, Exception exception)
    {
        HttpRequest? request = context.Request;
        string? requestBody = await GetRequestBodyAsync(request);
        IQueryCollection queryParams = request.Query;

        _logger.LogError(exception, "Unhandled exception occurred: {Message}. \nRequest Path: {Path}. \nQuery: {Query}. \nBody: {Body}.",
            exception.Message,
            request.Path,
            queryParams.ToString(),
            requestBody);
    }

    private static async Task<string> GetRequestBodyAsync(HttpRequest request)
    {
        if (request.Body.CanSeek)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            using StreamReader? reader = new StreamReader(request.Body);
            string body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }

        return string.Empty;
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An unexpected error occurred. Please try again later.",
            Detail = exception.Message
        };

        return context.Response.WriteAsJsonAsync(response);
    }

    #endregion
}
