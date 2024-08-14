using Catalog.Api.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database"));
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
if (builder.Environment.IsDevelopment()) 
{
    builder.Services.InitializeMartenWith<CatalogInitialData>(); 
}
var app = builder.Build();

// configure the HTTP request pipeline
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
app.UseExceptionHandler(opt =>
{

});
app.MapCarter();
app.Run();
