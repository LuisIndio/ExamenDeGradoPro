using Domain.events;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.TransactionEvents
{
    public class RollBackTransaction : INotificationHandler<TransactionDeleted>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        
        public RollBackTransaction(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(TransactionDeleted notification, CancellationToken cancellationToken)
        {
            var transactionDelete = await _transactionRepository.GetAsync(notification.Id);

            if (transactionDelete == null)
            {
                throw new Exception("La transaccion no existe");
            }

            decimal amount = transactionDelete.Amount;
            string tipo = transactionDelete.Type;

            var account = await _accountRepository.GetAsync(transactionDelete.AccountId);
            if (tipo == "ingreso")
            {
                account.ReduceBalanceAccount(amount);
            }
            else if (tipo == "egreso")
            {
                account.IncreaseBalanceAccount(amount);
            }

            await _accountRepository.UpdateAsync(account);
        }
    }
}
