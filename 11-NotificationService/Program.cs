using BestBank.Contracts;
using BestBank.NotificationService.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit( x=>
{
    x.AddConsumers(typeof(Program).Assembly);
    x.UsingRabbitMq((context,configurator) =>
    {
        configurator.Host(Environment.GetEnvironmentVariable("RabbitMQHost"));
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("AccountService2",false));
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresConnectionString"))
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
