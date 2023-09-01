**Account Management Services sends messages instead of invoking the Notification Service** 

This version of the Account Service uses RabbitMQ to send messages to the Notification Service. This allow the Account Management Service work even if the Notification Service is unavailable.

**Using Rabbit MQ**

To install the RabbitMQ dependencies in the project run the following commands:

```dotnet add package MassTransit.AspNetCore```

```dotnet add package MassTransit.RabbitMQ```

**Reference to the Contract**
Because the messages between the Producer and the Consumer must be the same, this project uses a new project as a reference, in this new project the class CreateNotificaiton is defined and used by both services.

To add a reference to the new project run the following command.

```dotnet add reference ..\BestBank.Contracts\BestBank.Contracts.csproj```

**Note**: A better approach is to create a nuget package form the Contracts projects and include this packages in both the Account Management Service and the Notification Service.
