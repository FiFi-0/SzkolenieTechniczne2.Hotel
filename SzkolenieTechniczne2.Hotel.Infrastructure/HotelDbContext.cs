using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Hotel.Domain.Entities;

namespace SzkolenieTechniczne2.Hotel.Infrastructure;

public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reservation>().ToTable("Reservations");
        modelBuilder.Entity<Room>().ToTable("Rooms");
        modelBuilder.Entity<Client>().ToTable("Clients");
    }
}
