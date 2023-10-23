using Domain.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Transactions
{
    public class TransactionFactory : ITransactionFactory
    {
        public Transaction CreateTransaction(string description, decimal amount, DateTime date, string type, Guid categoryId, Guid accountId, Guid userId)
        {
            return new Transaction(description, amount, date, type, categoryId, accountId,userId);
        }
    }
}
