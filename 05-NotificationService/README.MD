**Notification Service**
This first version of the Notification Service does not use a real Database and is created with the *web* template instead the *web-api* template. This will create a default minimal API sample.

**Create the project**

To create the Minimal Web API run the following command:

``` powershell
dotnet new web -n BestBank.NotificationService
```

**Add Swagger to the project**

Once the project is created, you can add swagger support, by default the template *web* does not include swagger, to do that you must run the following command:

``` poweshell
dotnet add package Swashbuckle.AspNetCore
```

Besides that, you need to add the following code to the program.cs before the  ```var app = builder.Build();``` line.

``` C#
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

Finally, add the following code to the program.cs after the  ```var app = builder.Build();``` line.

``` C#
app.UseSwagger();
app.UseSwaggerUI();
```
**Create an Extension to convert a CreateNotification class into a NotificationInfo class**

You will find the file ```Extension.cs``` in the main folder