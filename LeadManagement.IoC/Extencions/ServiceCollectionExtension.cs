using FluentValidation;
using LeadManagement.Application.Mapping;
using LeadManagement.Domain.Commands.Validation;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.Context;
using LeadManagement.Infra.Repositories;
using LeadManagement.Infra.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeadManagement.IoC.Extencions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        return services
            .AddRepositories(configuration)
            .AddApplicationServices(assemblies);
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["Database:SqlServer:ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException("Database connection string is not configured.");
        }

        services.AddDbContext<LeadDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IEventStore, EventStore>();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        services.AddTransient<IEmailService, EmailService>();

        services.AddValidatorsFromAssemblyContaining<AddLeadCommandValidator>();

        var config = TypeAdapterConfig.GlobalSettings;
        new LeadMapping();
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}
