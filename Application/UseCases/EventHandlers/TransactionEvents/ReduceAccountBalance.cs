using Domain.events;
using Domain.Factories.Accounts;
using Domain.Factories.Transactions;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.TransactionEvents
{
    public class ReduceAccountBalance : INotificationHandler<TransactionCreated>
    {
        private readonly IAccountRepository _accountRepository;

        public ReduceAccountBalance(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(TransactionCreated notification, CancellationToken cancellationToken)
        {
            var cuenta = await _accountRepository.GetAsync(notification.AccountId);

            if(notification.Type == "ingreso")
            {
                cuenta.IncreaseBalanceAccount(notification.Amount);
            }
            else if(notification.Type == "egreso")
            {
                cuenta.ReduceBalanceAccount(notification.Amount);
            }

            await _accountRepository.UpdateAsync(cuenta);
          
        }
    }
}
