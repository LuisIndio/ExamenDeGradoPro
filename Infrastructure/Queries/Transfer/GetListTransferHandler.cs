using Application.Dto;
using Application.Dto.Transaction;
using Application.UseCases.Transaction.Queries;
using Application.UseCases.Transfer.Queries;
using Infrastructure.EF.Config.ReadConfig;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Transfer
{
    internal class GetListTransferHandler : IRequestHandler<GetListTransferQuery, IEnumerable<TransferDto>>
    {
        private readonly DbSet<TransferReadModel>? transfers;

        public GetListTransferHandler(ReadDbContext context)
        {
            transfers = context.Transfers;
        }
        public async Task<IEnumerable<TransferDto>> Handle(GetListTransferQuery request, CancellationToken cancellationToken)
        {
            var query = transfers.AsNoTracking().AsQueryable();

            if (request.UserId != Guid.Empty)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var lista = await query.Select(x => new TransferDto
            {
                Id = x.Id,
                AccountId = x.AccountId,
                AccountId2 = x.AccountId2,
                Amount = x.Amount,
                Date = x.Date,
                UserId = x.UserId
            }).ToListAsync();

            return lista;
        }
    }
}
