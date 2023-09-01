using BestBank.AccountService;
using MassTransit;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddMassTransit( x=>
{
    x.UsingRabbitMq((context,configurator) =>
    {
        configurator.Host("127.0.0.1");
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("AccountService2",false));
    });
});


builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
