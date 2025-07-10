using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentasController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet("historial/{idCliente}")]
        public IActionResult ObtenerHistorial(int idCliente, [FromQuery] int pagina = 1)
        {
            try 
            {
                var historial = _ventaService.ObtenerHistorialCompras(idCliente, pagina);
                return Ok(historial);
            }
            
            catch (Exception ex) 
            {

                return StatusCode(500, $"Error al buscar el historial de compras: {ex.Message}");

            }
            
        }
    }
}
