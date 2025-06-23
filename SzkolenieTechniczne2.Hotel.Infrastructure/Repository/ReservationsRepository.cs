using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;

namespace SzkolenieTechniczne2.Hotel.Infrastructure.Repositories;

public class ReservationsRepository : IReservationsRepository
{
    private readonly HotelDbContext _db;

    public ReservationsRepository(HotelDbContext db)
    {
        _db = db;
    }

    public async Task<bool> DodajAsync(int clientId, int roomId, DateTime from, DateTime to, CancellationToken token)
    {
        try
        {
            const decimal cenaZaDzien = 250m;
            var liczbaDni = (to - from).Days;

            if (liczbaDni <= 0)
            {
                Console.WriteLine("⚠️ Błąd: liczba dni <= 0");
                return false;
            }

            var cena = liczbaDni * cenaZaDzien;

            var reservation = new Reservation
            {
                ClientId = clientId,
                RoomId = roomId,
                From = from,
                To = to,
                IsCanceled = false,
                Price = cena
            };

            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync(token);

            Console.WriteLine($"✅ Zatwierdzono rezerwację od {from} do {to}, cena: {cena} zł");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("⛔ Błąd dodawania rezerwacji: " + (ex.InnerException?.Message ?? ex.Message));
            return false;
        }
    }

    public async Task CancelAsync(long id)
    {
        var reservation = await _db.Reservations.FindAsync(id);
        if (reservation is not null)
        {
            reservation.IsCanceled = true;
            await _db.SaveChangesAsync();
        }
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await _db.Reservations
            .Include(r => r.Client)
            .Include(r => r.Room)
            .ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(long id)
    {
        return await _db.Reservations
            .Include(r => r.Client)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task DeleteAsync(Reservation reservation)
    {
        _db.Reservations.Remove(reservation);
        await _db.SaveChangesAsync();
    }
}
