using BestBank.AccountService.dtos;
using Microsoft.AspNetCore.Mvc;

namespace BestBank.AccountService;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{
    private static readonly List<AccountInfo> accounts = new List<AccountInfo>()
    {
        new AccountInfo(Guid.NewGuid(),"Luke", "Skywalker", 50, DateTimeOffset.UtcNow),
        new AccountInfo(Guid.NewGuid(),"Leia", "Organa", 40, DateTimeOffset.UtcNow),
        new AccountInfo(Guid.NewGuid(),"Ashoka", "Tano", 55, DateTimeOffset.UtcNow),
        new AccountInfo(Guid.NewGuid(),"Din", "Djarin", 35, DateTimeOffset.UtcNow),
    };

    [HttpGet]
    public IEnumerable<AccountInfo> Get()
    {
        return accounts;
    }

    [HttpGet("{id}")]
    public AccountInfo GetById(Guid id)
    {
        var account= accounts.Where(account => account.Id==id).SingleOrDefault();
        return account;
    }

    [HttpPost]
    public ActionResult<AccountInfo> Post(CreateAccount createAccount)
    {
        var account= new AccountInfo(Guid.NewGuid(),createAccount.FirstName,createAccount.LastName,createAccount.Balance,DateTimeOffset.UtcNow);
        accounts.Add(account);
        return CreatedAtAction(nameof(GetById),new {id=account.Id}, account);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,UpdateAccount updatedAccount)
    {
        var existingAccount= accounts.Where(account => account.Id==id).SingleOrDefault();
        var newAccount = existingAccount with 
        {
            Balance = updatedAccount.Amount,
            FirstName= updatedAccount.FirstName,
            LastName=updatedAccount.LastName
        };
        var index= accounts.FindIndex(existingAccount=>existingAccount.Id==id);
        accounts[index]=newAccount;
        return NoContent();
    }
}