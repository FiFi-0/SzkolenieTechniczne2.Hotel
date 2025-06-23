using Microsoft.AspNetCore.Components;
using SzkolenieTechniczne2.Hotel.Domain.Entities;
using SzkolenieTechniczne2.Hotel.Domain.Query.Reservation;
using SzkolenieTechniczne2.Hotel.Domain.Command.Reservation.Delete;
using MediatR;

namespace SzkolenieTechniczne2.Hotel.Components.Pages;

public partial class ReservationsPage : ComponentBase
{
    [Inject] private IMediator MediatorService { get; set; } = default!;

    protected List<Reservation>? rezerwacje;
    protected string? sukces;
    protected string? blad;

    protected override async Task OnInitializedAsync()
    {
        await Wczytaj();
    }

    protected async Task Wczytaj()
    {
        Console.WriteLine("🔄 Wczytywanie rezerwacji...");
        try
        {
            rezerwacje = await MediatorService.Send(new GetAllReservationsQuery());
            Console.WriteLine($"✅ Załadowano {rezerwacje?.Count ?? 0} rezerwacji.");
        }
        catch (Exception ex)
        {
            blad = $"Błąd wczytywania: {ex.Message}";
        }
    }

    protected async Task Usun(long id)
    {
        Console.WriteLine($"🧨 Próba usunięcia rezerwacji ID={id}");
        sukces = null;
        blad = null;

        try
        {
            var wynik = await MediatorService.Send(new DeleteReservationCommand(id));
            if (wynik.IsSuccess)
            {
                sukces = $"Rezerwacja ID={id} została usunięta.";
                Console.WriteLine("✅ Usunięto rezerwację");
            }
            else
            {
                blad = $"Nie udało się usunąć rezerwacji ID={id}.";
                Console.WriteLine("❌ Nie udało się usunąć rezerwacji");
            }
        }
        catch (Exception ex)
        {
            blad = $"❌ Wyjątek: {ex.Message}";
            Console.WriteLine($"⛔ Exception: {ex}");
        }

        await Wczytaj();
        await InvokeAsync(StateHasChanged);
    }
}
