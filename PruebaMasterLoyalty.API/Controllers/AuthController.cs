using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var result = _authService.Login(dto);
            if (result == null)
                return Unauthorized("Usuario o contraseña inválidos");

            return Ok(result);
        }
    }
}
