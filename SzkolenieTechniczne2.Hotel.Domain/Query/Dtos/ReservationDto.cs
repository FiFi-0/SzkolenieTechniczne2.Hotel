namespace SzkolenieTechniczne2.Hotel.Domain.Query.Dtos;

public record ReservationDto(
    long Id,
    ClientDto Client,
    RoomDto Room,
    DateTime From,
    DateTime To,
    bool IsCanceled,
    decimal Price
);
