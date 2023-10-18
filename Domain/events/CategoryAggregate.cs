using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record class CategoryAggregate : DomainEvent
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CategoryAggregate(Guid userId, string name, string description) : base(DateTime.Now)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }
    }
}
