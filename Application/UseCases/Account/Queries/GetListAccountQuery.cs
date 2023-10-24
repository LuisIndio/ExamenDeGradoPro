﻿using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Account.Queries
{
    public class GetListAccountQuery : IRequest<IEnumerable<AccountDto>>
    {
        public Guid UserId { get; set; }
    }
}
