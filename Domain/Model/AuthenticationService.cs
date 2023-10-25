using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository; 

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string email, string password)
        {
            User user = _userRepository.GetAsync(email).Result;

            if (user == null)
            {
                return null;
            }

            if (user.Password == password)
            {
                return user;
            }

            return null;
        }
    }

}
