**Account Management Service invoking Notification Service**

Before this version Account Service and Notification Service worked independently. Now we want to invoke the Notification Service if a certain condition is met.

**Invoke the Notification Service**

In order to invoke the notification service, you should add a ```Client``` class that will act as a proxy, this class must use the ```HttpClient``` to interact via http requests with the Notification Service. You can find the implementation in the Clients folder ```NotificationClient.cs```

**Important**

To test this version you need both databases and services working at the same time. In the first version of the ```NotificationClient.cs``` you can use a code like this:

``` C#
 public async void PushNotification(CreateNotification notification)
{
    string ?apiUrl = Environment.GetEnvironmentVariable("NotificationServiceEndpoint");  
    HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, notification);

    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}
```

**Handle communication errors** 

Because this kind of communication can result in failures, there are techniques to handle communication errors, time out, etc. Using the following package the application can implement patterns like Circuit Breaker.

``` powershell
dotnet add package Microsoft.Extensions.Http.Polly
```

For that the app implements a Policy, in this project that policy is in the ```ClientPolicy.cs``` file. This policy must be registered in the ```Program.cs``` file using this code.

``` C#
builder.Services.AddSingleton<ClientPolicy>( new ClientPolicy());
```

Finally, the invocation to the Notification Service must be wrapped with the policy.
``` C#
public async void PushNotification(CreateNotification notification)
{
    string ?apiUrl = Environment.GetEnvironmentVariable("NotificationServiceEndpoint"); 
        HttpResponseMessage response = await clientPolicy.WaitingRetry.ExecuteAsync( 
                () => httpClient.GetAsync(apiUrl));

    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}

```

Instead of this:
``` C#
public async void PushNotification(CreateNotification notification)
{
    string ?apiUrl = Environment.GetEnvironmentVariable("NotificationServiceEndpoint");  
    HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, notification);

    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}
```
***Note***
We're setting the URL of the API of the notification service with an environment variable, you need to set that value before running the application.