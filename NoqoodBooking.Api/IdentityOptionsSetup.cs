using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace NoqoodBooking.Api
{
    public class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
    {
        public void Configure(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequiredLength = 1;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    }
}
