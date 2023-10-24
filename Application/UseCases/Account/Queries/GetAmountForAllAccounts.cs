using Application.Dto.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.UseCases.Account.Queries
{
    public class GetAmountForAllAccounts : IRequest<decimal>
    {
        public Guid UserId { get; set; }
    }

}
