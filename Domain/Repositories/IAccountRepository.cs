using Domain.Model;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account,Guid>
    {
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid accountId);
        Task<Account> GetAsync(Guid accountId);
    }
}
