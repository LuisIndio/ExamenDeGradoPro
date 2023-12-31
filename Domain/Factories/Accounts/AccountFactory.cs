﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Accounts
{
    public class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(Guid userId, string name, decimal balance)
        {
            return new Account(userId, name, balance);
        }
    }
}
