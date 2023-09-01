using BestBank.Contracts;
using MassTransit;

namespace BestBank.NotificationService.Consumers
{
    public class CreateNotificationConsumer2: IConsumer<CreateNotification>
    {
        private readonly NotificationDbContext db;
        public CreateNotificationConsumer2(NotificationDbContext db)
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