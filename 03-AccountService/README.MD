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

**Create an Extension to convert an Entity.Account in an AccountInfo object**
You will find the file ```Extension.cs``` in the main folder