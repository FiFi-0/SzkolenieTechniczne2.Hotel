using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Hotel.Domain.Command; // <- Result jest tutaj
using SzkolenieTechniczne2.Hotel.Domain.Command.Reservation; // <- CreateReservationCommandHandler
using SzkolenieTechniczne2.Hotel.Domain.Repositories;
using SzkolenieTechniczne2.Hotel.Infrastructure;
using SzkolenieTechniczne2.Hotel.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Rejestracja bazy danych
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDatabase")));

// ✅ Rejestracja MediatR — rejestruje wszystkie Command/Handler/Query z odpowiednich projektów
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Result).Assembly,
        typeof(CreateReservationCommandHandler).Assembly,
        typeof(HotelDbContext).Assembly
    );
});

// Rejestracja repozytorium
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();

var app = builder.Build();

// Automatyczne utworzenie bazy danych (EnsureCreated — wersja bez migracji)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    db.Database.EnsureCreated(); // lub .Migrate() jeśli używasz migracji
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
