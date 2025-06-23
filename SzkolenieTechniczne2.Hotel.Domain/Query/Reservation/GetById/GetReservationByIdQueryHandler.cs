using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Query.Dtos;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Reservation
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto?>
    {
        private readonly IReservationsRepository _repository;

        public GetReservationByIdQueryHandler(IReservationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReservationDto?> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var r = await _repository.GetByIdAsync(request.Id);
            return r == null ? null : new ReservationDto(
                r.Id,
                new ClientDto(r.Client!.Id, r.Client.Name, r.Client.Email),
                new RoomDto(r.Room!.Id, r.Room.Number, r.Room.Capacity),
                r.From, r.To, r.IsCanceled, r.Price
            );
        }
    }
}