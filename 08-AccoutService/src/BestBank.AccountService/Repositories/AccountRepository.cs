using MongoDB.Driver;
using System.Reflection.Metadata;

namespace BestBank.AccountService.Repositories;
    public class AccountRepository
    {
        private const string collectionName="accounts";

        private readonly IMongoCollection<Entities.Account> dbCollection;
        private readonly FilterDefinitionBuilder<Entities.Account> filterBuilder = Builders<Entities.Account>.Filter;

        public AccountRepository()
        {
            var mongoClient= new MongoClient("mongodb://localhost:27017");
            var database= mongoClient.GetDatabase("accounts");
            dbCollection=database.GetCollection<Entities.Account>(collectionName);
        }

        public async Task<IReadOnlyCollection<Entities.Account>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Entities.Account> GetAsync(Guid id)
        {
            FilterDefinition<Entities.Account> filter = filterBuilder.Eq(entity => entity.Id,id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Entities.Account account)
        {
            if (account==null)
            {
                throw new ArgumentException(nameof(account));
            }
            await dbCollection.InsertOneAsync(account); 
        }

        public async Task UpdateAsync(Entities.Account account)
        {
            if (account==null)
            {
                throw new ArgumentException(nameof(account));
            }
            FilterDefinition<Entities.Account> filter = filterBuilder.Eq(entity => entity.Id,account.Id);
            await dbCollection.ReplaceOneAsync(filter,account);
        }

        public async Task DeleteAsync(Guid id)
        {
            FilterDefinition<Entities.Account> filter = filterBuilder.Eq(entity => entity.Id,id);
            await dbCollection.DeleteOneAsync(filter);
        }

    } 


