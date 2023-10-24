using Application.Dto.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Queries
{
    public class GetListTransactionDateQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public Guid UserSearchIdList { get; set; }

        public int Year { get; set;}
        public int Month { get; set;}
    }
}
