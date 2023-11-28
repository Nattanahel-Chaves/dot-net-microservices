This version of the Account Services uses MongoDB as Database and validates some fields as follow.

**To validate inputs**
In the *CreateAccount* and *UpdateAccount* public records, update the *FirsName* and *LastaName* fields with the Attribute:

```[Required]```

In the Balance field use ```[Range]```, and set the values you want to allow for that field.

For example:

``` C#
public record UpdateAccount ([Required]string    FirstName, [Required]string LastName, [Range(0,500)]decimal Amount);
```

**To use a real Database the projec includes now a folder named Entities**
To allow the use of a real DB we will include classes that interact with the database, those classes are called *Entities*. In this project you will find the entity *Account* under the folder *Entities*

**Installing MondoDB Driver**

To install the MondoDB driver Use te following command in the folder where the csproj file is located.
``` powershell
dotnet add package MongoDB.Driver 
```

**Run a MondoDB**
You can run the database in many ways, in your local environment, on the cloud or in a container, for this course the MongoDB runs in a container, if you want to run the container with mongo use the follow command:
``` powershell 
docker run -d --rm --name mongo -p 27017:27017 -v mongodbcontainerdata:/data/db mongo
```
**Important**

If you're running the docker engine on Windows, change the volume path in the previous command

``` powershell 
docker run -d --rm --name mongo -p 27017:27017 -v mongodbcontainerdata:c:\data\db mongo
```

**Create an Extension to convert an Entity.Account in an AccountInfo object**
You will find the file ```Extension.cs``` in the main folder

**Use of environment variables**
In the file ```AccountRepository.cs``` you will set the "connection string" to the MongoDB database, 

``` C#
var mongoClient= new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnString"));
```

Before you run your application, if you want to follow this approach, you need to create an environment variable using for example the following command, the value localhost:27017 should be adjust based on your environment:

``` bash
export MongoDBConnString="mongodb://localhost:27017"
```