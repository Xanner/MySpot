using MySpot.Application;
using MySpot.Core;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

builder.UseSerilog();

var app = builder.Build();
app.UseInfrastructure();
app.Run();
