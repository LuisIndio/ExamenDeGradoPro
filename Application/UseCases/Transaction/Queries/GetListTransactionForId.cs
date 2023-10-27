using Application.Dto.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Queries
{
    public class GetListTransactionForId : IRequest<IEnumerable<TransactionDto>>
    {
        public Guid TransactionId { get; set; }
    }
}
