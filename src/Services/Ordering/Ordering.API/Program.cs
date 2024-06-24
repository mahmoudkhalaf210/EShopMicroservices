using Ordering.API;
using Ordering.Application;
using Ordering.infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplicationServices()
    .AddinfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();


app.Run();
