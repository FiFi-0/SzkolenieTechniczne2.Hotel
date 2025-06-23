public class Client {
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int ReservationCount { get; set; }

    public bool IsLoyal => ReservationCount >= 5;
}