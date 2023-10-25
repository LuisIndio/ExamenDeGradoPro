using Application.UseCases.User.Command.LoginUser;
using Application.UseCases.User.Command.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUserCommand command)
        {
            // Envía el comando de inicio de sesión al manejador.
            var token = await mediator.Send(command);

            if (token != null)
            {
                // El inicio de sesión fue exitoso, se ha generado un token.
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
