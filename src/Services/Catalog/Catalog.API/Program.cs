var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

// configure the Http request pipeline ==> UseMethod

app.MapCarter();
app.Run();
