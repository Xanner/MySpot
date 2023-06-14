using Microsoft.EntityFrameworkCore;
using MySpot.Application;
using MySpot.Application.Services;
using MySpot.Core;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;
using MySpot.Infrastructure;
using MySpot.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MySpotDbContext>();
    dbContext.Database.Migrate();

    var weeklyParkingSpots = dbContext.WeeklyParkingSpots.ToList();
    if (!weeklyParkingSpots.Any())
    {
        var clock = new Clock();
        weeklyParkingSpots = new List<WeeklyParkingSpot>()
        {
            new (Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5")
        };
        dbContext.WeeklyParkingSpots.AddRange(weeklyParkingSpots);
        dbContext.SaveChanges();
    }
}

app.Run();
