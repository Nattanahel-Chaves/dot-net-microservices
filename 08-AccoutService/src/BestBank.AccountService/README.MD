**Update the files to validate inputs**
In the *CreateAccount* and *UpdateAccount* classes update the *FirsName* and *LastaName* fields with the Attribute>

```[Required]```

And the Balance field with ```[Range]``` definind the values you want to allow for that field.

For example:

```public record UpdateAccount ([Required]string    FirstName, [Required]string LastName, [Range(0,500)]decimal Amount);```


**Add Entities**
To allow the use of a real DB we will inclue classes that interac with the database, those classes are called *Entities*. In this project you will find the entity *Account* under the folder *Entities*


**Installing MondoDB Driver**

Use te follow command to install the MondoDB driver.
``` dotnet add package MongoDB.Driver ```

**Run a MondoDB container**
Use the follow command
``` docker run -d --rm --name mongo -p 27017:27017 -v mongodbcontainerdata:/data/db mongo```

**Invoke the Notification Service**
In order to invoke the notification service you should add a Client class and modificy the controller

**Handle communication errors** 
```dotnet add package Microsoft.Extensions.Http.Polly```