


var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var connectionDb = builder.Configuration.GetConnectionString("Database");
var connectionRedisDb = builder.Configuration.GetConnectionString("Redis");


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
builder.Services.Decorate<IBasketRepositroy, CachedBasketRepository>();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = connectionRedisDb;
});


builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddCarter();
builder.Services.AddHealthChecks()
    .AddNpgSql(connectionDb!)
    .AddRedis(connectionRedisDb!);



var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }); 

app.Run();
