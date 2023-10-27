using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest
    {
        public Guid TransactionId { get;  set; }
        public decimal Amount { get;  set; }
        public Guid AccountId { get;  set; }
    }
}
