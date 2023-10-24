using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record UserCreated : DomainEvent
    {
        public Guid UserId { get;  set; }
        public string? Name { get;  set; }
        public string? Email { get; set; }
        public string? Password { get;  set; }

        public UserCreated(Guid userid,DateTime Datenow) : base(Datenow)
        {
            UserId = userid;
            
        }
    }
}
