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
        public  Guid Id { get; set; }

        public TransactionDeleted(Guid id, DateTime dateTime) : base(dateTime)
        {
            Id = id;
        }
    }
}
