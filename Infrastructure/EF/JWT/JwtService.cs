using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.JWT
{
    // En la capa de Infraestructura (Infrastructure Layer)
    public class JwtService : IJwtService
    {
        public string GenerateToken(User user)
        {
            // Implementa la lógica de generación de tokens JWT aquí.
            // Deberás utilizar la configuración de seguridad adecuada.
            // A continuación, se proporciona un ejemplo simple.

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eB8qp56iVgx3fVrPbvN6WnBS1cPzRY+cKbFsNzvFzS0="); // Reemplaza esto con tu clave secreta real.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("userId", user.Id.ToString()),
                new Claim("email", user.Email)
            }),
                Expires = DateTime.UtcNow.AddHours(1), // Define la expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
