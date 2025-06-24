using SzkolenieTechniczne2.Hotel.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task AddAsync(Room room);
        Task<Room?> GetByIdAsync(long id);
        Task UpdateAsync(Room room);
    }
}