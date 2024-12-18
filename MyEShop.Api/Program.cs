using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MyEShop.Api;
using MyEShop.Api.Extensions;
using MyEShop.Application;
using MyEShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

#region Add Dependecies

builder.Services
    .RegisterInfrastructureConfiguration(builder.Configuration)
    .RegisterApplicationConfigurations(builder.Configuration)
    .RegisterConfigureHealthChecks(builder.Configuration);

#endregion

builder.Host.UseCustomSerilog();

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.Services.EnsureDatabaseMigratedAndSeeded();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

#region Helth Check

app.MapHealthChecks("/api/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(delegate (Options options)
{
    options.UIPath = "/healthcheck-ui";
});

#endregion

app.Run();