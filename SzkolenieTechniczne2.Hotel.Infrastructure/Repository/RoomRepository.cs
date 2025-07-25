﻿using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using SzkolenieTechniczne2.Hotel.Infrastructure; // Używamy tej przestrzeni nazw dla HotelDbContext
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Hotel.Infrastructure.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<Room?> GetByIdAsync(long id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }
    }
}