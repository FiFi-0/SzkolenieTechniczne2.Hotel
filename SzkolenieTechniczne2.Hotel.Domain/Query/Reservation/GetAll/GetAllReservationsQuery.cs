using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Reservation;

public class GetAllReservationsQuery : IRequest<List<SzkolenieTechniczne2.Hotel.Domain.Entities.Reservation>>
{
}
