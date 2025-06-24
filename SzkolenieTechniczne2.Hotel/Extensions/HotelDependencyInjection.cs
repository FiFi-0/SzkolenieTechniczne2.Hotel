using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using SzkolenieTechniczne2.Hotel.Infrastructure.Repositories;
using SzkolenieTechniczne2.Hotel.Infrastructure.Repository;


namespace SzkolenieTechniczne2.Hotel.Extensions;

public static class HotelDependencyInjection
{
    public static IServiceCollection AddHotel(this IServiceCollection services)
    {
        // Dodanie repozytoriów
        services.AddScoped<IReservationsRepository, ReservationsRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        // Rejestracja MediatR - WA¯NE!
        services.AddMediatR(cfg =>
        {
    cfg.RegisterServicesFromAssembly(typeof(IReservationsRepository).Assembly);
        });

        return services;
    }
}
