
using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Room.GetAll;

public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<Entities.Room>>
{
    private readonly IRoomRepository _roomRepository;

    public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<List<Entities.Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        return await _roomRepository.GetAllAsync();
    }
}