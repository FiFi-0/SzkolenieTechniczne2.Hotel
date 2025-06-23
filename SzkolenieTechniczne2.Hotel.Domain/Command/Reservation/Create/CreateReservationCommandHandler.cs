using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation;

public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result>
{
    private readonly IReservationsRepository _repo;

    public CreateReservationCommandHandler(IReservationsRepository repo) =>
        _repo = repo;

    public async Task<Result> Handle(CreateReservationCommand cmd, CancellationToken token)
    {
        var sukces = await _repo.DodajAsync(
            cmd.ClientId, cmd.RoomId, cmd.From, cmd.To, token
        );

        return sukces ? Result.Success() : Result.Fail("Nie uda³o siê dodaæ rezerwacji.");
    }
}
