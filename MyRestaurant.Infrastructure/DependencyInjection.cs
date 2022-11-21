using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRestaurant.Application.Common.Interfaces.Authentication;
using MyRestaurant.Application.Common.Interfaces.Services;
using MyRestaurant.Application.Persistence;
using MyRestaurant.Infrastructure.Authentication;
using MyRestaurant.Infrastructure.Persistence;
using MyRestaurant.Infrastructure.Services;

namespace MyRestaurant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}

