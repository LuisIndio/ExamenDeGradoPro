using Domain.Factories.Transactions;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transaction.Command.CreateTransaction
{
    internal class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionFactory _transactionFactory;
        private readonly IUnitOfWork _unitOfWork;
        public CreateTransactionHandler(ITransactionRepository transactionRepository, ITransactionFactory transactionFactory, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _transactionFactory = transactionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _transactionFactory.CreateTransaction(request.Description, request.Amount, request.Date, request.Type, request.CategoryId, request.AccountId, request.UserId);
            await _transactionRepository.CreateAsync(transaction);
            await _unitOfWork.Commit();
            return transaction.Id;

        }
    }
}
