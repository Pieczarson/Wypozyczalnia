public class Car
{
    public int Id { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsPrivate { get; set; }
    public double Rating { get; set; }
}