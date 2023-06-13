using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NoqoodBooking.Api
{
    public class JWTSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        /// add jwt Swagger Generation options
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "jwtToken_Auth_API", Version = "v1" });
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme.ToString(), new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter JWT token"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme.ToString()
                        }
                    },
                    new string[]{}
                }
            });

        }
    }
}
