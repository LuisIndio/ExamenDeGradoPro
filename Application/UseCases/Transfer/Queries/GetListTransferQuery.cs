using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transfer.Queries
{
    public class GetListTransferQuery : IRequest<IEnumerable<TransferDto>>
    {
        public Guid UserId { get; set;}
    }
}
