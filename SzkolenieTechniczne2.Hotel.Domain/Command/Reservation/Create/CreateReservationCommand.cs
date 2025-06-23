using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Reservation;

public class CreateReservationCommand : IRequest<Result>
{
    [Required]
    public int ClientId { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime From { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime To { get; set; }

    public CreateReservationCommand() { }

    public CreateReservationCommand(int clientId, int roomId, DateTime from, DateTime to)
    {
        ClientId = clientId;
        RoomId = roomId;
        From = from;
        To = to;
    }
}
