using Ordering.API;
using Ordering.API.Endpoints;
using Ordering.Application;
using Ordering.infrastructure;
using Ordering.infrastructure.Extentions;


var builder = WebApplication.CreateBuilder(args);

TypeAdapterConfig<CreateOrderRequest, CreateOrderCommand>.NewConfig()
    .Map(dest => dest.Order.orderItems, src => src.Order.orderItems)
    .PreserveReference(true);


builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddinfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


var app = builder.Build();

app.UseApiServices();
if (app.Environment.IsDevelopment()) {
    await app.InitializeDatabaseAsync();
}

app.Run();
