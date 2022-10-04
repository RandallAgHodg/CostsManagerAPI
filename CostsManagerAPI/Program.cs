using System.Text.Json;
using System.Text.Json.Serialization;
using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Database;
using CostsManagerAPI.Repositories;
using CostsManagerAPI.Services;
using CostsManagerAPI.Validations;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var jwtSecret = config.GetValue<string>("jwt:SecretKey");
var connectionString = config.GetValue<string>("Database:ConnectionString");
var clientUrl = config.GetValue<string>("FrontendUrl");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddAuthenticationJWTBearer(jwtSecret);
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions =>
        dbContextOptions
            .UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors(),
    ServiceLifetime.Singleton
);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSingleton<ICostRepository, CostRepository>();
builder.Services.AddSingleton<ICostService, CostService>();
builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
builder.Services.AddSingleton<IGroupService, GroupService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(options =>
{
    options.Errors.ResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(error => error.ErrorMessage).ToList()
        };
    };
    options.Errors.StatusCode = StatusCodes.Status422UnprocessableEntity;
    options.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
app.UseOpenApi();
app.UseSwaggerUi3(settings => settings.ConfigureDefaults());
app.Run();