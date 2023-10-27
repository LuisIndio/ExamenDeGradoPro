using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record TransactionUpdate : DomainEvent
    {
        public Guid Id { get; set; }
        public decimal Different { get; set; }
        public Guid AccountId { get; set; }
        public string Type { get; set; }


        public TransactionUpdate(Guid id,decimal different,Guid accountId,string type,DateTime datetime) : base(datetime)
        {
            Id = id;
            Different = different;
            AccountId = accountId;
            Type = type;
        }
    }
}
