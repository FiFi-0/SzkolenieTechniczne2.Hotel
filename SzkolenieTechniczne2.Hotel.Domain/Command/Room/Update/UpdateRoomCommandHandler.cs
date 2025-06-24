using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Command;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Room.Update;

public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Result>
{
    private readonly IRoomRepository _roomRepository;
    public UpdateRoomCommandHandler(IRoomRepository roomRepository) => _roomRepository = roomRepository;

    public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomToUpdate = await _roomRepository.GetByIdAsync(request.Id);
        if (roomToUpdate == null)
        {
            return Result.Fail("Pokój o podanym ID nie został znaleziony.");
        }

        roomToUpdate.Number = request.Number;
        roomToUpdate.Capacity = request.Capacity;
        roomToUpdate.IsAvailable = request.IsAvailable;
        roomToUpdate.LastModifiedAt = DateTime.UtcNow;
        roomToUpdate.ModifiedOn = DateTime.UtcNow;

        await _roomRepository.UpdateAsync(roomToUpdate);

        return Result.Success();
    }
}