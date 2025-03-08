using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());
        });
    }

    public static void ConfigurePostgreSQL(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "Lagerverwaltung API", 
                Version = "v1",
                Description = "API für die Lagerverwaltungsanwendung",
                Contact = new OpenApiContact
                {
                    Name = "Dein Name",
                    Email = "deine.email@example.com"
                }
            });
        });
    }
}