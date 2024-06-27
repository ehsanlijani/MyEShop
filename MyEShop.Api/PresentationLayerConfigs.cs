namespace MyEShop.Api;

public static class PresentationLayerConfigs
{

    public static IServiceCollection RegisterConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("MyShopDbContext"));

        services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                opt.SetApiMaxActiveRequests(1); //api requests concurrency    
                opt.AddHealthCheckEndpoint("feedback api", "/api/health"); //map health check api    

            }).AddInMemoryStorage();
        return services;

    }
}
