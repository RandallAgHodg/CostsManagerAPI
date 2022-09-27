using CostsCManagerAPI.Database;
using CostsCManagerAPI.Middleware;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var jwtSecret = config.GetValue<string>("jwt:SecretKey");
var connectionString = config.GetValue<string>("Database:ConnectionString");
var serverVersion = ServerVersion.AutoDetect(connectionString);
var clientUrl = config.GetValue<string>("FrontendUrl");

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddAuthenticationJWTBearer(jwtSecret);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions =>
        dbContextOptions
            .UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseCors(req =>
    req.WithOrigins(clientUrl)
        .AllowAnyHeader()
        .AllowAnyMethod()
);
app.UseSwaggerUi3(settings => settings.ConfigureDefaults());
app.Run();