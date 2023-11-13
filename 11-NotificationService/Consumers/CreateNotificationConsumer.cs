using BestBank.Contracts;
using BestBank.NotificationService.Models;
using MassTransit;

namespace BestBank.NotificationService.Consumers
{
    public class CreateNotificationConsumer: IConsumer<CreateNotification>
    {
        private readonly NotificationDbContext db;
        public CreateNotificationConsumer(NotificationDbContext db)
        {
            this.db=db;
        }
        public async Task Consume(ConsumeContext<CreateNotification> context)
        {
            var dataReceived= context.Message;
            var newnotification = new Notification
            {
                Id = Guid.NewGuid(),
                AccountId = dataReceived.AccountId,
                Message = dataReceived.Message,
                IsCompleted = false,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await db.Notifications.AddAsync(newnotification);
            await db.SaveChangesAsync();
        }
    }

}