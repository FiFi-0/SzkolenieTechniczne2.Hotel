using FluentValidation;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation;

public sealed class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.ClientId).GreaterThan(0);
        RuleFor(x => x.RoomId).GreaterThan(0);
        RuleFor(x => x.From).LessThan(x => x.To);
    }
}