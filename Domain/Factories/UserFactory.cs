using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(string username,string email, string password)
        {
            return new User(email, username, password);
        }

        public String LoginUser(string email, string password)
        {
            return "Login"+email;
        }

        public User RegisterUser(string username, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
