using NoqoodBooking.Api;
using NoqoodBooking.Application;
using NoqoodBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddPresentaion()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


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

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}



