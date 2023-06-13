﻿using NoqoodBooking.Application.Common.Interfaces.Authentication;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Application.Common.Interfaces.Services;
using NoqoodBooking.Infrastructure.Authentication;
using NoqoodBooking.Infrastructure.Persistence;
using NoqoodBooking.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NoqoodBooking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
