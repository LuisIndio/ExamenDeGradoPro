using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Transfer : AggregateRoot
    {
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid AccountId2 { get; private set; }
        public Guid UserId { get; private set; }

        public Transfer(DateTime date, decimal amount, Guid accountId, Guid accountId2, Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = date;
            Amount = amount;
            AccountId = accountId;
            AccountId2 = accountId2;
            UserId = userId;
        }
    }
}
