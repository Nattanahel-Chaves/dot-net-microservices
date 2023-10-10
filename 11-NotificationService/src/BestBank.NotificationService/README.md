**Final version of Notification Service**

This final version of the Notification Service not only allow to create notification via Http Requests, but is listening the RabbitMQ to get messages put by other services (Account Management Service in this case).

For that the project must create a class that implements the IConsumer interface.

Then register the MassTransit package in the ```program.cs``` but in this case the line ```x.AddConsumers(typeof(Program).Assembly);``` allow to start listening for messages.

```C#
builder.Services.AddMassTransit( x=>
{
    x.AddConsumers(Assembly.GetEntryAssembly());
    x.UsingRabbitMq((context,configurator) =>
    {
        configurator.Host("127.0.0.1");
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("Testing",false));
    });
});

```
Then you need to create a class that will be the consumer of the message. This class must implemente the IConsumer interface.
