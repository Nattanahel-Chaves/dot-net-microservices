**Account Management Services sends messages instead of invoking the Notification Service** 

This version of the Account Service uses RabbitMQ to send messages to the Notification Service. This allows the Account Management Service to work even if the Notification Service is unavailable.

**Using Rabbit MQ**

To install the RabbitMQ dependencies in the project, run the following commands:

``` powershell
dotnet add package MassTransit.AspNetCore

dotnet add package MassTransit.RabbitMQ
```

**Reference to the Contract**

Because the messages between the Producer and the Consumer must be the same, this project uses a new project as a reference, in this new project the class CreateNotificaiton is defined and used by both services.

To add a reference to the new project run the following command. This command will change if your folders have different names.

``` powershell
dotnet add reference ..\BestBank.Contracts\BestBank.Contracts.csproj
```

**Note**: A better approach is to create a nuget package form the Contracts projects and include this package in both the Account Management Service and the Notification Service.

Finally the MassTransit must be registered in the ```program.cs``` file.

``` C#
builder.Services.AddMassTransit( x=>
{
    x.UsingRabbitMq((context,configurator) =>
    {
        configurator.Host("127.0.0.1");
    });
});
```


In order to test this version of the service you need to update the Notification Server too, go to the 11-NotificationService section in the repository to make the changes. If you want to run the RabbitMQ as a container you can use this command:

``` powershell
docker run -d --rm --name rabbitmq -p 5672:5672 -p 15672:15672 -v rabbitmqdata:/var/lib/rabbitmq --hostname rabbitmq rabbitmq:management
```