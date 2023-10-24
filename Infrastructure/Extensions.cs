using Application;
using Domain.Model;
using Domain.Repositories;
using Infrastructure.EF;
using Infrastructure.EF.Context;
using Infrastructure.EF.JWT;
using Infrastructure.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplication();

            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WalletConnectionString"));
            });

            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WalletConnectionString"));
                
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<AuthenticationService>();
            return services;
        }
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
