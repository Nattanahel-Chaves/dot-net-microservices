using BestBank.NotificationService.dtos;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
   });


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => NotificationRepository.GetNotifications());

app.MapGet("/{id}", (Guid id) => NotificationRepository.GetNotification(id));

app.MapPost("/", (CreateNotification createNotificaiton) => NotificationRepository.CreateNotification(createNotificaiton));


app.Run();
