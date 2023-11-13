using BestBank.NotificationService.dtos;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => NotificationRepository.GetNotifications());

app.MapGet("/{id}", (Guid id) => NotificationRepository.GetNotification(id));

app.MapPost("/", (CreateNotification createNotificaiton) => NotificationRepository.CreateNotification(createNotificaiton));


app.Run();
