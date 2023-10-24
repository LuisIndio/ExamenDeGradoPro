using Domain.events;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.DeleteTransaction
{
    internal class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransactionHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetAsync(request.TransactionId);
            transaction.DeleteTransaction(transaction.Id);

            Guid transactionId = request.TransactionId;
            await _transactionRepository.DeleteAsync(transactionId);
            await _unitOfWork.Commit();

            return transactionId;
        }
    }
}
