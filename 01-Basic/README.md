**Most simple microservice with .net**

A .Net microservice is just a web project with API's. The simplest way to create a Web API in .Net 6 is running the following command:

``` powershell 
dotnet new webapi -n myprojectname 
```

This template will create a project that includes one controller and enabled swagger by default. The controller is located in the Controllers folder with the name ```WeatherForecastController.cs``` the template includes a class named ```WeatherForecast``` that has the definition of the object returned by the Web API every time the service receives a GET request. In the ```WeatherForecastController.cs``` file there is the logic to generate random values each time the WEB receives a request.

To run the project run the following command inside the folder where the csproj file is located.

``` powershell
dotnet run
``` 

In the properties subfolder in the ```launchSettings.json``` file you can find the port where the Web API is listening. **If** the value is for example ```https://localhost:7085``` you can use ```https://localhost:7085/swagger``` to launch swagger or only ```https://localhost:7085/WeatherForecast``` to make a request.
