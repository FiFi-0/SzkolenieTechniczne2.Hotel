using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using SzkolenieTechniczne2.Hotel.Domain.Command;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation.Delete;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Result>
{
    private readonly IReservationsRepository _repo;

    public DeleteReservationCommandHandler(IReservationsRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"🧨 Handler usuwania ID={request.Id}");
        var reservation = await _repo.GetByIdAsync(request.Id);

        if (reservation is null)
            return Result.Fail("Rezerwacja nie istnieje.");

        await _repo.DeleteAsync(reservation);
        return Result.Success();
    }
}
