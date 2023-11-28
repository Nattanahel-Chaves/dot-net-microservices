**Add DB Support**

This version of the Notification Services works with PostgreSQL, to use that the project import dependencies for Entity Framework and allow the migration process.

**Add Entity Framework for PostgreSQL**
Use the following commands

``` powershell
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

The ```EntityFrameworkCore.Design``` package is to allow the Code First approach.

**Add the Connection String to the PostgreSQL DB**
To communicate the Notification Service with the DB, the following code must be added into the ```program.cs``` file before the ```var app = builder.Build();``` line.

``` C#
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresConnectionString"))   
);
```

**How to create the DB in PostgreSQL based on the Model**

The Notification Service uses the Code First approach, so to create the DB in PostgreSQL uses the following code in the folder where the csproj file is located. Before that all the files in the Models subfolder must be created, for this project is only the ```Notification.cs``` file.

**Run the docker container with PostgreSQL**

Use the following command to start a container with a PostgreSQL DB, in this example *my_postgres* is the name of the container.

``` powershell
docker run -d --rm --name my_postgres -e POSTGRES_PASSWROD=Abc123* -p 5432:5432 postgres
```


(*Optional*)If you do not have the EF CLI installed run the following command
``` powershell
dotnet tool install --global dotnet-ef
```

Run the following in order to get the current version.

``` powershell
dotnet tool update --global dotnet-ef
```

Then run the following command to create the migration files.

``` powershell
dotnet ef migrations add firstmigration --project BestBank.NotificationService.csproj
```

Finally, run the following command to create the DB

``` powershell
dotnet ef database update firstmigration --project BestBank.NotificationService.csproj
```

**Important**

If you're running the PostgreSQL in a docker container, you need to run the previous command before starting the application for the first time, because you need to create the database and the tables.

**Use of environment variables**
In the file ```Program.cs``` you will set the "connection string" to the PostgreSQL database, 

``` C#
options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresConnectionString"))
```

Before you run your application, if you want to follow this approach, you need to create an environment variable using for example the following command. You need to replace the values in _Server_, _Port_, _Database_, _User_Id_ and _Password_ based on your own data.

``` bash
export PostgresConnectionString="Server=127.0.0.1;Port=5432;Database=NotificationDB;User Id=postgres;Password=Abc123*;"
```
