using Application.Dto.Transaction;
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
    internal class GetAmountForAllAccountsHandler : IRequestHandler<GetAmountForAllAccounts, decimal>
    {
        private readonly DbSet<AccountReadModel>? accounts;

        public GetAmountForAllAccountsHandler(ReadDbContext Context)
        {
            accounts = Context.Accounts;
        }

        public decimal CalculateTotalBalance(Guid userId)
        {
            var query = accounts.AsNoTracking().AsQueryable();

            if (userId != Guid.Empty)
            {
                query = query.Where(x => x.UserId == userId);
            }

            decimal totalBalance = query.Sum(x => x.Balance);
            return totalBalance;
        }

        public async Task<decimal> Handle(GetAmountForAllAccounts request, CancellationToken cancellationToken)
        {
            decimal totalBalance = CalculateTotalBalance(request.UserId);
            var result = new
        {
            TotalBalance = totalBalance
        };

        return totalBalance;
        }
    }

}
