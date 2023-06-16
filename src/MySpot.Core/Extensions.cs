using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.DomainServices;
using MySpot.Core.Policies;

namespace MySpot.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddSingleton<IReservationPolicy, RegularEmployeeReservationPolicy>()
            .AddSingleton<IReservationPolicy, ManagerReservationPolicy>()
            .AddSingleton<IReservationPolicy, BossReservationPolicy>()
            .AddSingleton<IParkingReservationService, ParkingReservationService>();

        return services;
    }
}
