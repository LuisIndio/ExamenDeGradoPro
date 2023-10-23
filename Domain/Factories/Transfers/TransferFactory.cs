using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Transfers
{
    public class TransferFactory : ITransferFactory
    {
        public Transfer CreateTransfer(DateTime date, decimal amount, Guid accountId, Guid accountId2, Guid userId)
        {
            return new Transfer(date, amount, accountId, accountId2, userId);
        }
    }
}
