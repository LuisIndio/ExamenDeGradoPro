using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record class AccountAggregate : DomainEvent
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        public AccountAggregate(Guid userId,string name, decimal balance) : base(DateTime.Now)
        {
            UserId = userId;
            Name= name;
            Balance = balance;
        }
    }
}
