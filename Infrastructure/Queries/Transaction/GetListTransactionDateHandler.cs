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
    internal class GetListTransactionDateHandler : IRequestHandler<GetListTransactionDateQuery, IEnumerable<TransactionDto>>
    {
        private readonly DbSet<TransactionReadModel>? transactions;

        public GetListTransactionDateHandler(ReadDbContext Context)
        {
            transactions = Context.Transactions;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetListTransactionDateQuery request, CancellationToken cancellationToken)
        {
            var query = transactions.AsNoTracking().AsQueryable();

            if (request.UserSearchIdList != Guid.Empty)
            {
                query = query.Where(x => x.UserId == request.UserSearchIdList);
            }

            if (request.Year != null && request.Month != null)
            {
                // Calcula el rango de fechas para el mes y año especificados
                int year = request.Year;
                int month = request.Month;
                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddTicks(-1);

                // Aplica el filtro de rango de fechas
                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
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
