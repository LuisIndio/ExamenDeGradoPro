using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    // En la capa de Dominio (Domain Layer)
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository; // Debes inyectar el repositorio de usuarios.

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string email, string password)
        {
            // Buscar el usuario por su correo electrónico.
            User user = _userRepository.GetAsync(email).Result;

            if (user == null)
            {
                // El usuario no existe.
                return null;
            }

            // Verificar si la contraseña coincide.
            if (user.Password == password)
            {
                // Las credenciales son válidas.
                return user;
            }

            // Contraseña incorrecta.
            return null;
        }
    }

}
