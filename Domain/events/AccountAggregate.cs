﻿using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.events
{
    public record class AccountAggregate : DomainEvent
    {
        public string Name { get; private set; }
        public string Balance { get; private set; }

        public AccountAggregate(string name, string balance) : base(DateTime.Now)
        {
            Name= name;
            Balance = balance;
        }
    }
}
