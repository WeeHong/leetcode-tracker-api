using LeetCodeTracker.Data;
using LeetCodeTracker.Repositories;
using LeetCodeTracker.Repositories.Contracts;
using LeetCodeTracker.Services;
using LeetCodeTracker.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeTracker.Extensions;

public static class Service
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opts =>
        {
            opts.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public static void ConfigureScoped(this IServiceCollection services)
    {
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuestionTrackerRepository, QuestionTrackerRepository>();
        services.AddScoped<IQuestionTrackerService, QuestionTrackerService>();
    }


    public static void ConfigurePostgreSQLContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(opts =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"));
        });
    }
}