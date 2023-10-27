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
    public class UpdateBalanceTransaction : INotificationHandler<TransactionUpdate>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UpdateBalanceTransaction(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(TransactionUpdate notification, CancellationToken cancellationToken)
        {
            //var transaction = await _transactionRepository.GetAsync(notification.Id);
            var account = await _accountRepository.GetAsync(notification.AccountId);

            //var diferencia = account.Balance - notification.Amount;

            if (notification.Different > 0 && notification.Type == "ingreso" || notification.Different < 0 && notification.Type == "egreso")
            {
                account.ReduceBalanceAccount(Math.Abs(notification.Different));
            }
            else 
            {
                account.IncreaseBalanceAccount(Math.Abs(notification.Different));
            }
            await _accountRepository.UpdateAsync(account);
        }
    }
}
