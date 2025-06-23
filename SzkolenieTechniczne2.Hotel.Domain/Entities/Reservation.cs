namespace SzkolenieTechniczne2.Hotel.Domain.Entities;

public class Reservation
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public Client? Client { get; set; }

    public long RoomId { get; set; }
    public Room? Room { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public bool IsCanceled { get; set; }
    public decimal Price { get; set; }
}
