using NoqoodBooking.Api.Errors;
using NoqoodBooking.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NoqoodBooking.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentaion(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, MyCustomProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}
