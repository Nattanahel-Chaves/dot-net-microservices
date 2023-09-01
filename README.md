# dot-net-microservices
This repository is meant to explain with simple samples how to design and develop robust microservices using .NET and C#. This hands-on guide will take you on a journey through the world of microservices architecture and help you craft scalable, maintainable, and fault-tolerant applications.

# Summary
This repository pretends to be a base for a small course about how to build microservices with .Net and C#. In the repository there are several .Net projects simulating 2 microservices of a fictinional Bank System.

The first microservices is the Account Management, and the second one is the Notification service of the Bank system. As you can see in the following image even both microservices are built with .Net, the Account Management Service uses MongoDB as Database and the API's are built with the Controller approach. The Notification service is built with the minimal API approach and uses PostgreSQL as a Database.

![image](https://github.com/Nattanahel-Chaves/dot-net-microservices/assets/118920372/85658d0a-9847-4fd2-a153-b63dba3f988a)

Each folder in the repository contains only the code for one of the microservices, in a different stage of development. For instance, the folder 02-Account Service is the first version of the service, while the 09-Account Service is the final version of the same service. Inside each project the README file will gide you about the commands and tasks to be completed.


- [The most basic microservice in .Net](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/01-Basic/src/01-basic#readme) 
- [Account Management Service with in memory DB.](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/02-AccountService/src/BestBank.AccountService#readme)
- [Account Management Service using MongoDB.](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/03-AccoutService/src/BestBank.AccountService#readme)
- [Docker-Compose to start MongoDB](https://github.com/Nattanahel-Chaves/dot-net-microservices/blob/main/04-Infrastructure/README.MD)
- Notification Service with in memory DB.
- Notification Service with PostgreSQL and Entity Framework.
- Docker-Compose to start MongoDB and PostgreSQL
- Account Management Service invoking Notification Service.
- Account Management Service producing and sending messages to RabbitMQ.
- Docker-Compose to start MongoDB, PostgreSQL and RabbitMQ.
- Notification Service consumming messages from RabbitMQ.

