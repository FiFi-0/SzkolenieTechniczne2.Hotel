using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Room.GetById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Entities.Room?>
{
    private readonly IRoomRepository _repository;
    public GetRoomByIdQueryHandler(IRoomRepository repository) => _repository = repository;

    public async Task<Entities.Room?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.RoomId);
    }
}