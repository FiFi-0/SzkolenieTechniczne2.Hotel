public class Room
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; } = true;
}