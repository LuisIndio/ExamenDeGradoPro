using Domain.events;
using Domain.Factories.Categories;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.CategoryEvents
{
    public class CreateCategoryWithUser : INotificationHandler<UserCreated>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory;

        public CreateCategoryWithUser(ICategoryRepository categoryRepository , ICategoryFactory categoryFactory)
        {
            _categoryRepository = categoryRepository;
            _categoryFactory = categoryFactory;
        }
        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {

            var Casa = _categoryFactory.CreateCategory(userId : notification.UserId, name : "Casa",description: "esta categoria es para los gastos de la casa");
            var viajes = _categoryFactory.CreateCategory(userId: notification.UserId, name: "viajes", description: "esta categoria es para los viajes");
            var entretenimiento = _categoryFactory.CreateCategory(userId: notification.UserId, name: "entretenimiento", description: "esta categoria es para los entretenimientos");
            await _categoryRepository.CreateAsync(Casa);
            await _categoryRepository.CreateAsync(viajes);
            await _categoryRepository.CreateAsync(entretenimiento);


        }
    }
}
