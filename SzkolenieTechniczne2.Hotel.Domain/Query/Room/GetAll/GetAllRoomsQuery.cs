using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using System.Collections.Generic;

namespace SzkolenieTechniczne2.Hotel.Domain.Query.Room.GetAll;

public class GetAllRoomsQuery : IRequest<List<Entities.Room>>
{
}