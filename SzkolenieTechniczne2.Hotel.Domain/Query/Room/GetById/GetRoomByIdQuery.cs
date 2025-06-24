using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Room.GetById;

public class GetRoomByIdQuery : IRequest<Entities.Room?>
{
    public long RoomId { get; set; }
    public GetRoomByIdQuery(long roomId) => RoomId = roomId;
}