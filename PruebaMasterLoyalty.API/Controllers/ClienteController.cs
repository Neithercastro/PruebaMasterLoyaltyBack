using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost("registro")]
        public IActionResult Registrar([FromBody] ClienteRegistroDTO dto)
        {
            try
            {
                _service.RegistrarCliente(dto);
                return Ok(new { mensaje = "Cliente registrado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PorUsuario/{idUsuario}")]
        public IActionResult ObtenerClientePorUsuario(int idUsuario)
        {
            try
            {
                var cliente = _service.ObtenerClientePorUsuario(idUsuario);

                if (cliente == null)
                    return NotFound(new { mensaje = "No se encontró cliente para este usuario." });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Error al buscar cliente: {ex.Message}" });
            }
        }
    }
}
