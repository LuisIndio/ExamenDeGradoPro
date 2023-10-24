using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record TransactionCreated : DomainEvent
    {
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string? Type { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }

        public TransactionCreated(decimal amount, DateTime date, string type,Guid accountId, Guid userId, DateTime Datenow) : base(Datenow)
        {
            Amount = amount;
            Date = date;
            Type = type;
            AccountId = accountId;
            UserId = userId;
        }
    }
}
