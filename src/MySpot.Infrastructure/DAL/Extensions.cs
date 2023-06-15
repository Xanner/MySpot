using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.Repositories;
using MySpot.Infrastructure.DAL.Repositories;

namespace MySpot.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString = "Host=localhost;Database=MySpot;Username=postgres;Password=password";
        services
            .AddDbContext<MySpotDbContext>(x => x.UseNpgsql(connectionString))
            .AddScoped<IWeeklyParkingSpotRepository, PostgresWeeklyParkingSpotRepository>()
            .AddHostedService<DatabaseInitializer>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}
