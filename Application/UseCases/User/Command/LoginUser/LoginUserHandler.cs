using Domain.Factories;
using Domain.Model;
using Domain.Repositories;
using Infrastructure.EF.JWT;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Command.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string> // Cambia el tipo de retorno a string
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IJwtService _jwtService;

        public LoginUserHandler(AuthenticationService authenticationService, IJwtService jwtService)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
        }

        public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var authenticatedUser = _authenticationService.AuthenticateUser(request.Email, request.Password);
            
            if (authenticatedUser != null)
            {
                // Si las credenciales son válidas, generas un token JWT utilizando IJwtService.
                string token = _jwtService.GenerateToken(authenticatedUser);

                // Devuelve el token como string.
                return Task.FromResult(token);
            }

            // En caso de credenciales inválidas, puedes lanzar una excepción o devolver un valor predeterminado (por ejemplo, null).
            return Task.FromResult("error al autenticar"); // Lanza una excepción o maneja el error según tus necesidades.
        }
    }
}
