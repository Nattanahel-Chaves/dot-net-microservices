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

**Add Entity Framework for PostgreSQL**
Use the following command

```dotnet add package Microsoft.EntityFrameworkCore```
```dotnet add package Microsoft.EntityFrameworkCore.Design```
```dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL```


**Add the Connection String to the PostgreSQL DB**
Add the following code in the appsettings.json file

```
"ConnectionString":{
    "PostgreSQLConnection":"Server=127.0.0.1;Port=5432;Database=NotificationDB;User Id=postgres;Password="
  }
```
**Add the dependency injection of the DB to the project**
In order to use the DBContext with the PostgreSQL use the following line in the program.cs file before the ```var app = builder.Build();``` line.

```
var connectionString= builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<NotificationDbContext>(options =>
options.UseNpgsql(connectionString));
```
**How to create the DB in PostgreSQL based on the Model**
In this example we're using the CodeFirst approach, so to create the DB in ProgreSQL is the following code in the folder where the csproj file is located.

*(Optional)If you do not have the EF CLI installed run the following command
```
dotnet tool install --global dotnet-ef
```

or the following in order to check the version is the lastone

```dotnet tool update --global dotnet-ef```

```
dotnet ef migrations add firstmigration --project BestBank.NotificationService.csproj
```

```
dotnet ef database update firstmigration --project BestBank.NotificationService.csproj
```

**Run the docker container with PostgreSQL**
Use the following command
```docker run --name my_postgres -e POSTGRES_PASSWORD=Abc123* -p 5432:5432 -d postgres```


**Using Rabbit MQ**
To install Rabbit MQ in the project run the following commands
```dotnet add package MassTransit.AspNetCore```
```dotnet add package MassTransit.RabbitMQ```