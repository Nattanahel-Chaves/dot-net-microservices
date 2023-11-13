public class Notification
{
    public Guid Id { get; set; }
    public string ?AccountId { get; set; }
    public string ?Message { get; set; }
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
} 