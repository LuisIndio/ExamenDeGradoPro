using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Transaction
{
    public class Transaction : AggregateRoot
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public TypeTransaction Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid AccountId { get; private set; }

        public Transaction (string description, decimal amount, DateTime date, TypeTransaction type, Guid categoryId, Guid accountId)
        {
            Description = description;
            Amount = amount;
            Date = date;
            Type = type;
            CategoryId = categoryId;
            AccountId = accountId;
        }
    }
}
