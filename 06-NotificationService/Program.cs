using BestBank.NotificationService.dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;





var builder = WebApplication.CreateBuilder(args);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=NotificationDB;User Id=postgres;Password=Abc123*;")
);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", async (NotificationDbContext db) => await db.Notifications.ToListAsync());

app.MapGet("/{id}", async (Guid id, NotificationDbContext db) =>
{
    return await db.Notifications.FindAsync(id)
    is Notification notification
    ? Results.Ok(notification)
    : Results.NotFound();
});

app.MapPost("/", async (CreateNotification createNotification, NotificationDbContext db) =>
{
    Random random = new Random();
    var result = random.Next(1, 10);
    if (result > 4)
    {
        Console.WriteLine("Error 500");
        return Results.StatusCode(StatusCodes.Status500InternalServerError);

    }
    else
    {
        var newnotification = new Notification
        {
            Id = Guid.NewGuid(),
            AccountId = createNotification.AccountId,
            Message = createNotification.Message,
            IsCompleted = false,
            CreatedDate = DateTimeOffset.UtcNow
        };


        await db.Notifications.AddAsync(newnotification);
        await db.SaveChangesAsync();
        Console.WriteLine("Ok 200");
        return Results.Created($"/{newnotification.Id}", newnotification);
        
    }
});

app.Run();
