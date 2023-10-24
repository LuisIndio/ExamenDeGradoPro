using Application.Dto.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Queries
{
    public class GetListTransactionQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public Guid UserSearchIdList { get; set; }

    }
}
