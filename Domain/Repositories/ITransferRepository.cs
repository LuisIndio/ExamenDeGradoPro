using Domain.Model;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITransferRepository : IRepository<Transfer, Guid>
    {
        Task CreateAsync(Transfer transfer);
        Task UpdateAsync(Transfer transfer);
        Task DeleteAsync(Guid transferId);
    }
}
