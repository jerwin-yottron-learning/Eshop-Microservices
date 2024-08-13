var builder = WebApplication.CreateBuilder(args);
//Add services to the container
var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddCarter();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

// configure the HTTP request pipeline

app.UseExceptionHandler(opt =>
{

});
app.MapCarter();
app.Run();
