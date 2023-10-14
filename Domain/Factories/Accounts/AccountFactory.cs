using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Accounts
{
    public class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(string name, string balance)
        {
            return new Account(name, balance);
        }
    }
}
