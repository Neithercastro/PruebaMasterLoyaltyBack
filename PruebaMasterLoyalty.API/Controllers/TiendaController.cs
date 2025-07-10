using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly TiendaService _service;

        public TiendaController(TiendaService service) 
        {
            _service = service;
        }

        [HttpPost("registro")]
        public IActionResult Registrar([FromBody] TiendaRegistroDTO dto)
        {
            try
            {
                _service.RegistrarTienda(dto);
                return Ok("Tienda registrada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

     

    }
}
