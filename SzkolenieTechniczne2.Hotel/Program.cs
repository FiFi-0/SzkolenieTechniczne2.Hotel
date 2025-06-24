using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Hotel.Domain.Command;
using SzkolenieTechniczne2.Hotel.Domain.Command.Reservation;
using SzkolenieTechniczne2.Hotel.Domain.Repositories; // Ten using jest potrzebny
using SzkolenieTechniczne2.Hotel.Infrastructure;
using SzkolenieTechniczne2.Hotel.Infrastructure.Repositories; // Ten using jest potrzebny
using System.Reflection;
using SzkolenieTechniczne2.Hotel.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
});

// Rejestracja bazy danych
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDatabase")));

// Rejestracja MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Result).Assembly,
        typeof(CreateReservationCommandHandler).Assembly,
        typeof(HotelDbContext).Assembly
    );
});

// Rejestracja repozytoriów
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
// --- DODANA LINIA ---
builder.Services.AddScoped<IRoomRepository, RoomRepository>();


var app = builder.Build();

// Automatyczne utworzenie bazy danych
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    db.Database.Migrate(); // Używamy migracji!
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();