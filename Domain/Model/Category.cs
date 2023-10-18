using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Category : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public Category(Guid userId, string name, string description)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Description = description;
        }

        public void EditCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
       

        public Category() { }
    }
}
