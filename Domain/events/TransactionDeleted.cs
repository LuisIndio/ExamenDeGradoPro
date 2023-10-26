using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record TransactionDeleted : DomainEvent
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }

        public TransactionDeleted(string type,decimal amount ,Guid accountId,DateTime dateTime) : base(dateTime)
        {
            Type = type;
            Amount = amount;
            AccountId = accountId;
        }
    }
}
