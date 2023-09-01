using BestBank.AccountService.dtos;

namespace BestBank.AccountService;

public static class Extensions
{
    public static AccountInfo ConverToAccountInfo(this AccountService.Entities.Account account)
    {
        return new AccountInfo(account.Id,account.FirsName,account.LastName,account.Balance,account.CreatedDate);
    }
}