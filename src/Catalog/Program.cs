using BuildingBlocks.Behaviours;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container
var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddCarter();

var app = builder.Build();

// configure the HTTP request pipeline
app.MapCarter();
app.Run();
