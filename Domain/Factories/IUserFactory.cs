using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
     public interface IUserFactory
    {
        User RegisterUser(string username,string email, string password);
        String LoginUser(string email, string password);
    }
}
