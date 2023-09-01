namespace BestBank.NotificationService.dtos;

public record NotificationInfo (Guid Id, string AccountId, string Message, bool IsCompleted, DateTimeOffset CreatedDate);