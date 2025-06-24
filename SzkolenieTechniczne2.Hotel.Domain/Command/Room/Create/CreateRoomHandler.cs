using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Room.Create
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result>
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var newRoom = new Entities.Room
            {
                Number = request.Number,
                Capacity = request.Capacity,
                IsAvailable = request.IsAvailable,

                // Ustawiamy pola śledzenia zgodnie ze schematem bazy danych
                CreatedAt = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                CreatedByUserId = Guid.Empty, // Używamy pustego GUID jako wartości zastępczej
                ModifiedByUserId = Guid.Empty // Używamy pustego GUID jako wartości zastępczej
            };

            await _roomRepository.AddAsync(newRoom);

            return Result.Success();
        }
    }
}