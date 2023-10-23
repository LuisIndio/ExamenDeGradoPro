using Domain.Factories.Transfers;
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
    internal class TransferRepository : ITransferRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public TransferRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task CreateAsync(Transfer transfer)
        {
            await _writeDbContext.Transfers.AddAsync(transfer);
        }

        public async Task DeleteAsync(Guid transferId)
        {
            var transfer = _writeDbContext.Transfers.Find(transferId);
            _writeDbContext.Remove(transfer);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Transfer?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Transfer transfer)
        {
            _writeDbContext.Transfers.Update(transfer);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
