

using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var connectionDb = builder.Configuration.GetConnectionString("Database");

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));

});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(connectionDb!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();


builder.Services.AddScoped<IBasketRepositroy, BasketRepositroy>();
builder.Services.AddScoped<IBasketRepositroy>(provider => {
    var basketRepostory = provider.GetRequiredService<BasketRepositroy>();
    return new CachedBasketRepository(basketRepostory, provider.GetRequiredService<IDistributedCache>());
});
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddCarter();


var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();
