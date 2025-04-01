using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.Context;
using LeadManagement.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeadManagement.IoC.Extencions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddRepositories(configuration)
            .AddApplicationServices();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["Database.SqlServer.ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException("Database connection string is not configured.");
        }

        services.AddDbContext<LeadDbContext>(options =>
        {
            options.UseSqlServer(configuration["Database.SqlServer.ConnectionString"]);
        });

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
