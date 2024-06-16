using BuildingBlocks.Behaviours;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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


app.UseExceptionHandler(exceptionHandlerApp => {

    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null) {
            return;
        }

        var proplemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.StackTrace,
        };

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, exception.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(proplemDetails);
    });

});



app.Run();
