using Application.Dto;
using Application.UseCases.Account.Queries;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Account
{
    internal class GetListAccountHandler : IRequestHandler<GetListAccountQuery, IEnumerable<AccountDto>>
    {
        private readonly DbSet<AccountReadModel>? accounts;

        public GetListAccountHandler(ReadDbContext Context)
        {
            accounts = Context.Accounts;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetListAccountQuery request, CancellationToken cancellationToken)
        {
            var query = accounts.AsNoTracking().AsQueryable();

            if (request.UserId != Guid.Empty)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var lista = await query.Select(x => new AccountDto
            {
                Id = x.Id,
                Name = x.Name,
                Balance = x.Balance,
                UserId = x.UserId
            }).ToListAsync();

            return lista;
        }
    }
}
