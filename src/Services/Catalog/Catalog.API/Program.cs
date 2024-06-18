

var builder = WebApplication.CreateBuilder(args);

// add services to the container

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// configure the Http request pipeline ==> UseMethod

app.MapCarter();




app.Run();
