using Domain.events;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.TransferEvents
{
    public class UpdateBalanceAccountTransfer : INotificationHandler<TransferCreated>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateBalanceAccountTransfer(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(TransferCreated notification, CancellationToken cancellationToken)
        {
            var cuenta = await _accountRepository.GetAsync(notification.AccountId);
            var cuenta2 = await _accountRepository.GetAsync(notification.AccountId2);
            
            if(cuenta == null || cuenta2 == null)
            {
                throw new Exception("La cuenta no existe");
            }
            cuenta.ReduceBalanceAccount(notification.Amount);
            cuenta2.IncreaseBalanceAccount(notification.Amount);

            await _accountRepository.UpdateAsync(cuenta);
            await _accountRepository.UpdateAsync(cuenta2);

        }
    }
}
