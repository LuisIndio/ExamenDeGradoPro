using Domain.events;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User : AggregateRoot
    {
        public string Name { get;  private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;

            var userCreatedEvent = new UserCreated(this.Id,DateTime.Now);
            AddDomainEvent(userCreatedEvent);
            

        }

        /*public void AddCategory(Guid userId, string name, string description)
         {
             var category = new Category(userId, name, description);
             _categories.Add(category);

             var evento= new CategoryAggregate(userId, name, description);
             AddDomainEvent(evento);
         }*/
        /* public void AddAccount(Guid userId, string name, decimal balance)
         {
             Account account = new Account(userId,name, balance);
             _account.Add(account);

             var evento = new AccountAggregate(userId, name, balance);
             AddDomainEvent(evento);
         }*/
        public User() { }
    }
}
