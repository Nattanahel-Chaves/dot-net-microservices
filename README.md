# dot-net-microservices

This repository contains simple samples to explain how to design and develop robust microservices using .NET and C#. This hands-on guide walks you through microservices architecture and helps you build scalable, maintainable, and fault-tolerant applications.

## Summary

This repository is intended as a base for a small course on building microservices with .NET and C#. It includes several .NET projects that simulate two microservices in a fictional banking system.

The first microservice is Account Management, and the second is the Notification Service. Although both microservices use .NET, the Account Management Service uses MongoDB and is built with a controller-based API, while the Notification Service uses the minimal API style and PostgreSQL.

![image](https://github.com/Nattanahel-Chaves/dot-net-microservices/assets/118920372/85658d0a-9847-4fd2-a153-b63dba3f988a)

Each folder in the repository contains the code for one microservice in a different stage of development. For example, `02-AccountService` is an early version of the service, while `09-AccountService` is the final version of the same service. Inside each project, the README file guides you through the commands and tasks for that stage.

## Repository structure

- [01-Basic](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/01-Basic#readme) — the most basic microservice in .NET
- [02-AccountService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/02-AccountService#readme) — Account Management Service with in-memory DB
- [03-AccountService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/03-AccountService#readme) — Account Management Service using MongoDB
- [04-Infrastructure](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/04-Infrastructure#readme) — Docker Compose to start MongoDB
- [05-NotificationService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/05-NotificationService#readme) — Notification Service with in-memory DB
- [06-NotificationService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/06-NotificationService#readme) — Notification Service with PostgreSQL and Entity Framework
- [07-Infrastructure](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/07-Infrastructure#readme) — Docker Compose to start MongoDB and PostgreSQL
- [08-AccountService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/08-AccountService#readme) — Account Management Service invoking Notification Service
- [09-AccountService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/09-AccountService#readme) — Account Management Service producing and sending messages to RabbitMQ
- [10-Infrastructure](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/10-Infrastructure#readme) — Docker Compose to start MongoDB, PostgreSQL, and RabbitMQ
- [11-NotificationService](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/11-NotificationService#readme) — Notification Service consuming messages from RabbitMQ
- [12-Contracts](https://github.com/Nattanahel-Chaves/dot-net-microservices/tree/main/12-Contracts#readme) — shared contracts between services

## Getting started

1. Install the .NET SDK version required by the project you want to run.
2. Open the target folder in Visual Studio or VS Code.
3. Follow that folder's README for setup and run instructions.

## Notes

- Each project folder is self-contained and may require different dependencies.
- Use the project README files for service-specific instructions and details.
