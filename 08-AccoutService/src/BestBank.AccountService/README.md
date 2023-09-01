**Account Management Service invoking Notification Service**

Before this version Account Service and Notification Service worked independently. Now we want to invoke the Notification Service if certain condition is meet.

**Invoke the Notification Service**

In order to invoke the notification service you should add a Client class that will act as a proxy, this class must use the ```HttpClient``` to interac via http requests with the Notification Service.

**Handle communication errors** 
Because this kind of communcation can result in failures there are techniques to handled communication errors, time out, etc. Using the following package the application can implemente patterns like Circuit Braker.

```dotnet add package Microsoft.Extensions.Http.Polly```

For that the app implements a Policy, in this project that policy is in the ```ClientPolicy``` file. This policy must be registered in the ```program.cs``` file.

```builder.Services.AddSingleton<ClientPolicy>( new ClientPolicy());```

Finally the invoke to the Notification Service must be wrapped with the policy.
```
    HttpResponseMessage response = await clientPolicy.WaitingRetry.ExecuteAsync( 
                () => httpClient.GetAsync(apiUrl));
```

Instead of this:
```
    HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, notification);
```
