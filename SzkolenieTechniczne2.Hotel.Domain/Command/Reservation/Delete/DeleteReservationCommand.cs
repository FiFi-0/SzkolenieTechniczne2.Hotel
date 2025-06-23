using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Command;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation.Delete;

public record DeleteReservationCommand(long Id) : IRequest<Result>;
