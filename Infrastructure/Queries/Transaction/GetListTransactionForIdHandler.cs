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
    internal class GetListTransactionForIdHandler : IRequestHandler<GetListTransactionForId, IEnumerable<TransactionDto>>
    {
        private readonly DbSet<TransactionReadModel>? transactions;
        public GetListTransactionForIdHandler(ReadDbContext Context)
        {
            transactions = Context.Transactions;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetListTransactionForId request, CancellationToken cancellationToken)
        {
            var query = transactions.AsNoTracking().AsQueryable();

            if (request.TransactionId != Guid.Empty)
            {
                query = query.Where(x => x.Id == request.TransactionId);
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
