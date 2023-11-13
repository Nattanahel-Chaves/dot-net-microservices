using BestBank.NotificationService.dtos;

public static class Extensions
{
     public static NotificationInfo ConverToNotificationInfo(this CreateNotification createNotification, 
            Guid id, bool isCompleted, DateTimeOffset createdDate)
     {
         var notification= new NotificationInfo (id,
            createNotification.AccountId,
            createNotification.Message,
            isCompleted,
            createdDate
            );
         return notification;
            
    }
}