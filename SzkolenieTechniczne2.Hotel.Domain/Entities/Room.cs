// Plik: Domain/Entities/Room.cs

using SzkolenieTechniczne2.Hotel.Common.Entities; // Upewnij si�, �e ta przestrze� nazw jest poprawna

namespace SzkolenieTechniczne2.Hotel.Domain.Entities
{
    public class Room : BaseEntity, ITrackedEntity
    {
        public string Number { get; set; } = null!;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        // Relacja do rezerwacji
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        // Pola z ITrackedEntity (je�li istniej�)
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}