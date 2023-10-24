using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record TransferCreated : DomainEvent
    {
        
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid AccountId2 { get; private set; }
        public Guid UserId { get; private set; }

        public TransferCreated(DateTime date, decimal amount, Guid accountId, Guid accountId2, Guid userId, DateTime Datenow) : base(Datenow)
        {
            Date = date;
            Amount = amount;
            AccountId = accountId;
            AccountId2 = accountId2;
            UserId = userId;
        }

    }
}
