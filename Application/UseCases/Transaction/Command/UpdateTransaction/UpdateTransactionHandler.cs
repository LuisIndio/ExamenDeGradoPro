using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.UpdateTransaction
{
    internal class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTransactionHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
           var transaction = await _transactionRepository.GetAsync(request.TransactionId);
           
            if(transaction == null)
            {
                throw new Exception("Transaction not found");
            }

            var diferencia = transaction.Amount - request.Amount;
            transaction.UpdateTransaction(diferencia, request.AccountId,transaction.Type);

           transaction.EditAmount(request.Amount);

            await _transactionRepository.UpdateAsync(transaction);

            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
    
