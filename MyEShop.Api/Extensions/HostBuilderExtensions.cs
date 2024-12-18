using Serilog;

namespace MyEShop.Api.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((_, _, loggerConfig) =>
        {
            loggerConfig
                .WriteTo.Console() // Log to console
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day); // Log to file with daily rolling
        });
    }
