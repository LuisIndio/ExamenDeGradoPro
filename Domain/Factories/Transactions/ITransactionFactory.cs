using Domain.Model.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Transactions
{
    public interface ITransactionFactory
    {
        Transaction CreateTransaction(string description, decimal amount, DateTime date, string type, Guid categoryId, Guid accountId,Guid UserId);
    }
}
