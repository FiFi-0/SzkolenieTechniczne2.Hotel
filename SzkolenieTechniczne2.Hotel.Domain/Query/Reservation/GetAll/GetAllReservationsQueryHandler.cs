using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using SzkolenieTechniczne2.Hotel.Domain.Query.Reservation;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Reservation;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<SzkolenieTechniczne2.Hotel.Domain.Entities.Reservation>>
{
    private readonly IReservationsRepository _repo;

    public GetAllReservationsQueryHandler(IReservationsRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<SzkolenieTechniczne2.Hotel.Domain.Entities.Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
