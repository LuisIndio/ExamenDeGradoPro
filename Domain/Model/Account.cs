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
        public Guid UserId { get; private set; }
        public string? Name { get; private set; }
        public decimal? Balance { get; private set; }

        public Account(Guid userId, string name, decimal balance)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Balance = balance;
        }

        public void EditAccount(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
        public void IncreaseBalanceAccount(decimal balance)
        {
            Balance += balance;
        }
        public void ReduceBalanceAccount(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar la reducción.");
            }
        }

        public void IncreaseBalanceAccount2(decimal balance)
        {
            Balance += balance;
        }
        public void ReduceBalanceAccount2(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar la reducción.");
            }
        }

        public Account() { }

    }
}
