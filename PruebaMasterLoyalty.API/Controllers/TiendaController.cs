using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _service;

        public TiendaController(ITiendaService service) 
        {
            _service = service;
        }

        [HttpPost("registro")]
        public IActionResult Registrar([FromBody] TiendaRegistroDTO dto)
        {
            try
            {
                _service.RegistrarTienda(dto);
                return Ok(new { mensaje = "Tienda registrada correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("Listar")]
        public IActionResult ListarTiendas([FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = _service.ListarTiendas(pagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Error al listar tiendas: {ex.Message}" });
            }
        }


        [HttpGet("PorUsuario/{idUsuario}")]
        public IActionResult ObtenerTiendaPorUsuario(int idUsuario)
        {
            try
            {
                var tienda = _service.ObtenerTiendaPorUsuario(idUsuario);

                if (tienda == null)
                    return NotFound(new { mensaje = "No se encontró tienda para este usuario." });

                return Ok(tienda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Error al buscar tienda: {ex.Message}" });
            }
        }


    }
}
