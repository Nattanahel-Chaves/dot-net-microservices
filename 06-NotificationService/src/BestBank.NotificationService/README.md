**Add DB Support**

This version of the Notification Services works with PostgreSQL, to use that the project import dependencies for EntityFramework and allow the migration process.

**Add Entity Framework for PostgreSQL**
Use the following command

```dotnet add package Microsoft.EntityFrameworkCore```
```dotnet add package Microsoft.EntityFrameworkCore.Design```
```dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL```

The ```EntityFrameworkCore.Design``` package is to allow the Code First approach.

**Add the Connection String to the PostgreSQL DB**
To communicate the Notification Service with the DB, the following code must be added into the ```program.cs``` file before the ```var app = builder.Build();``` line.

```
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=NotificationDB;User Id=postgres;Password=Abc123*;")
);
```

**How to create the DB in PostgreSQL based on the Model**

The Notification Service uses the CodeFirst approach, so to create the DB in PostgreSQL use the following code in the folder where the csproj file is located. Before that all the files in the Models subfolder must be created, for this project is only the Notification.cs file.

**Run the docker container with PostgreSQL**

Use the following command to start a container with a PostgreSQL DB, in this example *my_postgres* is the name of the container.

```docker run --name my_postgres -e POSTGRES_PASSWORD=Abc123* -p 5432:5432 -d postgres```


(*Optional*)If you do not have the EF CLI installed run the following command
```
dotnet tool install --global dotnet-ef
```

Run the following in order to get the current version.

```dotnet tool update --global dotnet-ef```

Then run the following command to create the migration files.

```
dotnet ef migrations add firstmigration --project BestBank.NotificationService.csproj
```

Finally run the following command to create the DB

```
dotnet ef database update firstmigration --project BestBank.NotificationService.csproj
```
