using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Account : AggregateRoot
    {
        public string Name { get; private set; }
        public string Balance { get; private set; }

        public Account(string name, string balance)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = balance;
        }

        public void EditAccount(string name, string balance)
        {
            Name = name;
            Balance = balance;
        }
        public Account() { }

    }
}
