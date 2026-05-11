using Microsoft.AspNetCore.Mvc;
using Operations.DTOs;
using Operations.Services;

namespace Operations.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            var usuario = _auth.ValidarUsuario(
                request.Username,
                request.Password
            );

            if (usuario == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            return Ok(new LoginResponseDTO
            {
                Username = usuario.Username,
                Rol = usuario.Rol
            });
        }
    }
}
