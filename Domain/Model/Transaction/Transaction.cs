using Domain.events;
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
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string? Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }

        public Transaction (string description, decimal amount, DateTime date, string type, Guid categoryId, Guid accountId, Guid userId)
        {
            Id = Guid.NewGuid();
            Description = description;
            Amount = amount;
            Date = date;
            Type = type;
            CategoryId = categoryId;
            AccountId = accountId;
            UserId = userId;

            var transactionCreatedEvent = new TransactionCreated(amount, date, type, accountId, userId, DateTime.Now);
            AddDomainEvent(transactionCreatedEvent);
        }
        public void DeleteTransaction()
        {
            var transactionDeletedEvent = new TransactionDeleted(Type,Amount,AccountId,DateTime.Now);
            AddDomainEvent(transactionDeletedEvent);
        }
        
        public Transaction() { }
    }
}
