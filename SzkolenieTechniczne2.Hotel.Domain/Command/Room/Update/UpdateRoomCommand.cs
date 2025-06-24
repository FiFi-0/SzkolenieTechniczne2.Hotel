using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Command;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Room.Update;

public class UpdateRoomCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
}