Docker Compose

Because the fictional Bank System includes more than one service, each one with a different DataBase we use a Docker Compose file to start all the containers at the same time.

To run the docker compose use the following commmand

``` powershell
docker-compose up
```

*This version of the file includes the configuration for MongoDB, PostgreSQL and RabbitMQ*
