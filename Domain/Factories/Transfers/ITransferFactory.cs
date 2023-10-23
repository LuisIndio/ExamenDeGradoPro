using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Transfers
{
    public interface ITransferFactory
    {
        Transfer CreateTransfer(DateTime date, decimal amount, Guid accountId, Guid accountId2, Guid userId);
    }
}
