using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transfer.Command.CreateTransfer
{
    public record CreateTransferCommand : IRequest<Guid>
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public Guid AccountId2 { get; set; }
        public Guid UserId { get; set; }

        public CreateTransferCommand(DateTime date, decimal amount, Guid accountId, Guid accountId2, Guid userId)
        {
            Date = date;
            Amount = amount;
            AccountId = accountId;
            AccountId2 = accountId2;
            UserId = userId;
        }
    }
}
