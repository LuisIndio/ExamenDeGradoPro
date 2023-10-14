using Domain.Model;
using Domain.Repositories;
using Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public AccountRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task CreateAsync(Account account)
        {
            await _writeDbContext.Accounts.AddAsync(account);
        }

        public async Task DeleteAsync(Guid accountId)
        {
            var account = _writeDbContext.Accounts.Find(accountId);
            _writeDbContext.Remove(account);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Account?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Account account)
        {
            _writeDbContext.Accounts.Update(account);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
