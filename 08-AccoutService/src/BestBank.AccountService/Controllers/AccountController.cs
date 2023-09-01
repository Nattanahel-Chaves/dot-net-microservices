using BestBank.AccountService.Clients;
using BestBank.AccountService.dtos;
using BestBank.AccountService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BestBank.AccountService;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{
    private readonly ClientPolicy clientPolicy;

    public AccountController(ClientPolicy clientPolicy)
    {
        this.clientPolicy=clientPolicy;
    }
    private readonly AccountRepository accountsRepository = new();

    [HttpGet]
    public async Task<IEnumerable<AccountInfo>> GetAsync()
    {
        var accounts =(await accountsRepository.GetAllAsync())
                        .Select(account => account.ConverToAccountInfo());
        return accounts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AccountInfo>> GetByIdAsync(Guid id)
    {
        var account= await accountsRepository.GetAsync(id);
        if (account == null)
            return NotFound();
        else
            return account.ConverToAccountInfo();
    }

    [HttpPost]
    public async Task<ActionResult<AccountInfo>> PostAsync(CreateAccount createAccount)
    {
        var account= new Entities.Account 
        {
            FirsName= createAccount.FirstName,
            LastName= createAccount.LastName,
            Balance= createAccount.Balance,
            CreatedDate= DateTimeOffset.UtcNow
        };
        await accountsRepository.CreateAsync(account);
        return CreatedAtAction(nameof(GetByIdAsync),new {id=account.Id}, account);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id,UpdateAccount updatedAccount)
    {
        var existingAccount= await accountsRepository.GetAsync(id);
        if (existingAccount == null)
            return NotFound();
        existingAccount.FirsName= updatedAccount.FirstName;
        existingAccount.LastName=updatedAccount.LastName;
        existingAccount.Balance=updatedAccount.Amount;
        await accountsRepository.UpdateAsync(existingAccount);

        var notification = new CreateNotification(id.ToString(), $"Your new balance is {existingAccount.Balance}");
        HttpClient httpClient=new HttpClient();
        var notificationClient= new NotificationClient(httpClient,clientPolicy);
        notificationClient.GetNotifications();

        
        return NoContent();
    }
}