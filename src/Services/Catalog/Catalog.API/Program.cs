var builder = WebApplication.CreateBuilder(args);

// add services to the container

var app = builder.Build();

// configure the Http request pipeline ==> UseMethod

app.Run();
