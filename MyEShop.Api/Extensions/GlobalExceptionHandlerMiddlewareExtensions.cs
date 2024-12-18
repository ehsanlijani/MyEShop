using MyEShop.Api.Middleware;

namespace MyEShop.Api.Extensions;

public static class GlobalExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
          => builder.UseMiddleware<ExceptionHandlingMiddleware>();
}
