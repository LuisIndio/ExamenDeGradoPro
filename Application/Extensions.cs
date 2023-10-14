﻿using Domain.Factories;
using Domain.Factories.Accounts;
using Domain.Factories.Categories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserFactory,UserFactory>();
            services.AddScoped<IAccountFactory, AccountFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            return services;
        }
    }
}
