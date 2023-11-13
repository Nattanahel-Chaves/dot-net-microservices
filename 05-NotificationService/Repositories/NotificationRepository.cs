using BestBank.NotificationService.dtos;

public class NotificationRepository
 {
   private static readonly List<NotificationInfo> notifications = new List<NotificationInfo>()
   {
     new NotificationInfo (Guid.NewGuid(), Guid.NewGuid(), "Your new balance is $50", false,DateTimeOffset.UtcNow),
     new NotificationInfo (Guid.NewGuid(), Guid.NewGuid(), "Your new balance is $55", false, DateTimeOffset.UtcNow),
     new NotificationInfo (Guid.NewGuid(), Guid.NewGuid(), "Your new balance is $40", false, DateTimeOffset.UtcNow) 
   };

   public static List<NotificationInfo> GetNotifications() 
   {
     return notifications;
   } 

   public static NotificationInfo ? GetNotification(Guid id) 
   {
     return notifications.SingleOrDefault(notification => notification.Id == id);
   } 

   public static NotificationInfo CreateNotification(CreateNotification createNotification) 
   {
    var newnotification=createNotification.ConverToNotificationInfo(Guid.NewGuid(),false,DateTimeOffset.UtcNow);
     notifications.Add(newnotification);
     return newnotification;
   }

  
 }