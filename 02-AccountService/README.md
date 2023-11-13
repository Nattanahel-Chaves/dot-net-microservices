**Account Management Service**
This service will be in charge of operations like adding a new account, get the information of all the accounts, get the information of one account and updated one account. For that the service includes one Controller called AccountController.cs, with the *Get*, *GetById*, *Post* and *Put* operations.

In this first version of the service, the information is stored in memory. That's mean that every time the service restarts, the data is lost.

Besides the AccountController the service includes 3 public records to use as a data response/request. AccountInfo, CreateAccount and UpdateAccount.

If you want to follow the tutorial, you need to

1. Run the command 
``` powershell
dotnet new webapi -n myprojectname
```
2. Delete the ```WeatherForecastController.cs``` and ```WeatherForecast.cs``` files created by default.
3. Create a new Controller called ```AccountController.cs``` inside the ```Controllers``` folder.
4. Create a new folder called ```dtos```
5. Add 3 records to the new folder, ```AccounInfo.cs```, ```CreateAccount.cs``` and ```UpdateAccount.cs```
6. Implement the code base on the tutorial.
