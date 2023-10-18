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
        private readonly ICollection<Category>? _categories;
        public IEnumerable<Category>? Categories => _categories;

        //private readonly ICollection<Account>? _account;
        //public IEnumerable<Account>? Accounts => _account;

        public string Name { get;  private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            _categories = new List<Category>();
            //_account = new List<Account>();
        }
       public void AddCategory(Guid userId, string name, string description)
        {
            var category = new Category(userId, name, description);
            _categories.Add(category);

            var evento= new CategoryAggregate(userId, name, description);
            AddDomainEvent(evento);
            //_categories.Add(category);
            //AddEvent(new CategoryAddedEvent(category));
        }/*
        public void AddAccount(string name, string balance)
        {
            Account account = new Account(name, balance);
            _account.Add(account);

            var evento = new AccountAggregate(name, balance);
            AddDomainEvent(evento);
            //_categories.Add(category);
            //AddEvent(new CategoryAddedEvent(category));
        }*/
        public User() { }

    }
    
}
