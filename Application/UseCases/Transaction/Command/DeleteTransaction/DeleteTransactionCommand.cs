﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest<Guid>
    {
        public Guid TransactionId { get; set;}
    }
}
