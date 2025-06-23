using SzkolenieTechniczne2.Hotel.Domain.Entities;

namespace SzkolenieTechniczne2.Hotel.Domain.Repositories;

public interface IReservationsRepository
{
    Task<bool> DodajAsync(int clientId, int roomId, DateTime from, DateTime to, CancellationToken token);
    Task CancelAsync(long id);
    Task<List<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(long id);
    Task DeleteAsync(Reservation reservation);

}
