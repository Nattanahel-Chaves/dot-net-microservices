**Account Management Service**
This service will be in charge of operations like adding a new account, get the information of all the accounts, get the information of one account and updated one account. For that the service includes one Controller called AccountController.cs, with the *Get*, *GetById*, *Post* and *Put* operations.

In this first version of the service, the information is stored in memory. That's mean that every time the service restarts, the data is lost.

Besides the AccountController the service includes 3 public records to use as a data response/request. AccountInfo, CreateAccount and UpdateAccount.
