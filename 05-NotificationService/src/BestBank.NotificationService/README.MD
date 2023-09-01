**Create the project**

To create the Minimal Web API run the following command

```dotnet new web -n BestBank.NotificationService```

**Add Swagger to the project**
To add Swagger support  run the following command

```dotnet add package Swashbuckle.AspNetCore --version 6.1.4```

Add the following code to the program.cs

```
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
   });
```

Finally Add the following code to the program.cs

```
app.UseSwagger();
app.UseSwaggerUI();
```