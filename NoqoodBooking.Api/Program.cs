using NoqoodBooking.Api;
using NoqoodBooking.Application;
using NoqoodBooking.Domain.UserAggregate;
using NoqoodBooking.Infrastructure;
using NoqoodBooking.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddPresentaion()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);

    builder.Services.AddIdentityCore<User>()
.AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.ConfigureOptions<IdentityOptionsSetup>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureOptions<JWTSwaggerGenOptions>();


}

var app = builder.Build();
{


    if (app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/error-development");
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/error");
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}



