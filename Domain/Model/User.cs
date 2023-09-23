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
        }
        public void EditUser(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User() { }

    }
    
}
