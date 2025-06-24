using MediatR;
using SzkolenieTechniczne2.Hotel.Domain.Command;

namespace SzkolenieTechniczne2.Hotel.Domain.Command.Room.Create
{
    public class CreateRoomCommand : IRequest<Result>
    {
        // Inicjalizujemy Number, aby spełnić wymagania C# dotyczące wartości non-null
        public string Number { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}