using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Reservation
{
    public class GetReservationByIdQuery : IRequest<ReservationDto?>
    {
        public long Id { get; }

        public GetReservationByIdQuery(long id)
        {
            Id = id;
        }
    }
}
