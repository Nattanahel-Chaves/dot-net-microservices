using BestBank.AccountService.Entities;

namespace BestBank.AccountService.Repositories
{
    public interface IAccountRepository
    {
        Task<IReadOnlyCollection<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(Guid id);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
    }
}