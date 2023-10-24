using Application.Dto.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Queries
{
    public class GetListTransactionForAll : IRequest<IEnumerable<TransactionDto>>
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AccountId { get; set; }

    }
}
