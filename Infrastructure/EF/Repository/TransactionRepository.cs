using Domain.Model.Transaction;
using Domain.Repositories;
using Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public TransactionRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task CreateAsync(Transaction transaction)
        {
            await _writeDbContext.Transactions.AddAsync(transaction);
        }

        public async Task DeleteAsync(Guid transactionId)
        {
            var transaction = _writeDbContext.Transactions.Find(transactionId);
            _writeDbContext.Remove(transaction);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Transaction?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _writeDbContext.Transactions.Update(transaction);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
