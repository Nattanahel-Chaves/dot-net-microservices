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
    private readonly IAccountRepository accountsRepository;

    public AccountController(IAccountRepository accountRepository, ClientPolicy clientPolicy)
    {
        this.accountsRepository=accountRepository;
        this.clientPolicy=clientPolicy;

    }
    

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
        var account= await accountsRepository.GetByIdAsync(id);
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
            FirstName= createAccount.FirstName,
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
        var existingAccount= await accountsRepository.GetByIdAsync(id);
        if (existingAccount == null)
            return NotFound();
        existingAccount.FirstName= updatedAccount.FirstName;
        existingAccount.LastName=updatedAccount.LastName;
        existingAccount.Balance=updatedAccount.Amount;
        await accountsRepository.UpdateAsync(existingAccount);

        var notification = new CreateNotification(id.ToString(), $"Your new balance is {existingAccount.Balance}");
        HttpClient httpClient=new HttpClient();
        //First version (Without Polly)
        //var notificationClient1= new NotificationClient(httpClient);
        //notificationClient1.PushNotification(notification);
        
        //Second version with Polly
        var notificationClient= new NotificationClient(httpClient,clientPolicy);
        notificationClient.PushNotification(notification);
        
        return NoContent();
    }
}