using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using MyEShop.Api;
using MyEShop.Application;
using MyEShop.Infrastructure;
using MyEShop.Infrastructure.Persistence.Context;
using MyEShop.Infrastructure.Persistence.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

#region Add Dependecies

builder.Services
    .RegisterInfrastructureConfiguration(builder.Configuration)
    .RegisterApplicationConfigurations(builder.Configuration)
    .RegisterConfigureHealthChecks(builder.Configuration);

#endregion

var app = builder.Build();

app.Services.EnsureDatabaseMigratedAndSeeded();

// Configure the HTTP request pipeline.
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