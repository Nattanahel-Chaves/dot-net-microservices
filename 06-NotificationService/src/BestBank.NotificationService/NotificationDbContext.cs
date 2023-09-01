using Microsoft.EntityFrameworkCore;

public class NotificationDbContext : DbContext
{
    public DbSet<Notification> Notifications => Set<Notification>();

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options): base(options)
    {
    }
}