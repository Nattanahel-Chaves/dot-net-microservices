using BestBank.AccountService.dtos;
using BestBank.AccountService.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using BestBank.Contracts;

namespace BestBank.AccountService;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{
    private readonly IPublishEndpoint publishEndpoint;
    private readonly IAccountRepository accountsRepository;

    public AccountController(IPublishEndpoint publishEndpoint, IAccountRepository accountsRepository)
    {
        this.publishEndpoint=publishEndpoint;
        this.accountsRepository=accountsRepository;
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
        var existingAccount= await accountsRepository.GetByIdAsync(id);
        if (existingAccount == null)
            return NotFound();
        existingAccount.FirsName= updatedAccount.FirstName;
        existingAccount.LastName=updatedAccount.LastName;
        existingAccount.Balance=updatedAccount.Amount;
        await accountsRepository.UpdateAsync(existingAccount);

        //notificationProducer.SendNotification( notification);
        if (existingAccount.Balance<50)
        {
            await publishEndpoint.Publish(new CreateNotification
                (existingAccount.Id.ToString(),$"Your new balance is $ {existingAccount.Balance}"));
        }
        return NoContent();
    }
}