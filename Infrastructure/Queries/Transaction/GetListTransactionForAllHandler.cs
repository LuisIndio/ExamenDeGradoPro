using Application.Dto.Transaction;
using Application.UseCases.Transaction.Queries;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Transaction
{
    internal class GetListTransactionForAllHandler : IRequestHandler<GetListTransactionForAll, IEnumerable<TransactionDto>>
    {
        private readonly DbSet<TransactionReadModel>? transactions;

        public GetListTransactionForAllHandler(ReadDbContext Context)
        {
            transactions = Context.Transactions;
        }
        public async Task<IEnumerable<TransactionDto>> Handle(GetListTransactionForAll request, CancellationToken cancellationToken)
        {
            var query = transactions.AsNoTracking().AsQueryable();

            if (request.UserId != Guid.Empty)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (request.CategoryId != Guid.Empty)
            {
                query = query.Where(x => x.CategoryId == request.CategoryId);
            }
            if (request.AccountId != Guid.Empty)
            {
                query = query.Where(x => x.AccountId == request.AccountId);
            }
            var lista = await query.Select(x => new TransactionDto
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                Date = x.Date,
                Type = x.Type,
                CategoryId = x.CategoryId,
                AccountId = x.AccountId,
                UserId = x.UserId
            }).ToListAsync();

            return lista;
        }
    }
}
