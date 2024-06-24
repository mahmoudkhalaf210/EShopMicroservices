using Ordering.API;
using Ordering.Application;
using Ordering.infrastructure;
using Ordering.infrastructure.Extentions;


var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplicationServices()
    .AddinfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

app.UseApiServices();
if (app.Environment.IsDevelopment()) {
    await app.InitializeDatabaseAsync();
}

app.Run();
