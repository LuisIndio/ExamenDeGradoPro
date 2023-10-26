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
        
        public RollBackTransaction(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(TransactionDeleted notification, CancellationToken cancellationToken)
        {   
            var account = await _accountRepository.GetAsync(notification.AccountId);

            if (notification.Type == "ingreso")
            {
                account.ReduceBalanceAccount(notification.Amount);
            }
            else if (notification.Type == "egreso")
            {
                account.IncreaseBalanceAccount(notification.Amount);
            }

            await _accountRepository.UpdateAsync(account);
        }
    }
}
