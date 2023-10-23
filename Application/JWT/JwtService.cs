using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.JWT
{
    // En la capa de Aplicación (Application Layer)
    public interface IJwtService
    {
        string GenerateToken(User user);
    }


}
