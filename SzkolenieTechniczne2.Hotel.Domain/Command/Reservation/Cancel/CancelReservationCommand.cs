using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Command;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation.Cancel;

public class CancelReservationCommand : IRequest<Result>
{
    public long ReservationId { get; }

    public CancelReservationCommand(long reservationId)
    {
        ReservationId = reservationId;
    }
}