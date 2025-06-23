using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation.Cancel;

public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, Result>
{
    private readonly IReservationsRepository _repo;

    public CancelReservationCommandHandler(IReservationsRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"🧨 Handler wywołany z ID = {request.ReservationId}");

        try
        {
            await _repo.CancelAsync(request.ReservationId);
            Console.WriteLine($"✅ Rezerwacja {request.ReservationId} anulowana w repozytorium.");
            return Result.Success();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Błąd anulowania: {ex.Message}");
            return Result.Fail("Wystąpił błąd przy anulowaniu rezerwacji.");
        }
    }
}