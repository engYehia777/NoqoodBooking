using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoqoodBooking.Application.Common.Interfaces.Authentication;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Application.Common.Interfaces.Services;
using NoqoodBooking.Infrastructure.Authentication;
using NoqoodBooking.Infrastructure.Persistence;
using NoqoodBooking.Infrastructure.Services;
using System.Text;

namespace NoqoodBooking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}
