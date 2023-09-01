using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace BestBank.NotificationService.dtos;

public record NotificationInfo (Guid Id, Guid AccountId, string Message, bool IsCompleted, DateTimeOffset CreatedDate);