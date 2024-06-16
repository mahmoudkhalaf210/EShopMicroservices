using BuildingBlocks.Behaviours;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// configure the Http request pipeline ==> UseMethod

app.MapCarter();
app.Run();
