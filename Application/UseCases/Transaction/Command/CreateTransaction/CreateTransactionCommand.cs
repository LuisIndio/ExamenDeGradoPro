using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.CreateTransaction
{
    public record CreateTransactionCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string? Type { get; set; }
        public Guid AccountId { get; set; }

        public CreateTransactionCommand(string name, string description, decimal amount, DateTime date, Guid categoryId, string type,Guid accountId, Guid userId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Date = date;
            CategoryId = categoryId;
            Type = type;
            AccountId = accountId;
            UserId = userId;
        }
    }
}
