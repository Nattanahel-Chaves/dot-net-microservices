using System;

namespace BestBank.AccountService.dtos;

public record AccountInfo(Guid Id, string FirstName, string LastName, decimal Balance, DateTimeOffset CreatedDate );