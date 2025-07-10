using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        [HttpGet("Obtener-Carrito-Cliente/{idCliente}")]
        public IActionResult ObtenerCarrito(int idCliente)
        {
            var carrito = _carritoService.ObtenerCarritoPorCliente(idCliente);
            return Ok(carrito);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarProducto([FromBody] AgregarProductoCarritoDTO dto)
        {
            _carritoService.AgregarProducto(dto);
            return Ok("Producto agregado al carrito.");
        }

        [HttpPut("Actualizar-Cantidad")]
        public IActionResult ActualizarCantidad([FromBody] ActualizarCantidadCarritoDTO dto)
        {
            _carritoService.ActualizarCantidad(dto);
            return Ok("Cantidad actualizada.");
        }

        [HttpDelete("Eliminar")]
        public IActionResult EliminarProducto([FromBody] EliminarProductoCarritoDTO dto)
        {
            _carritoService.EliminarProducto(dto);
            return Ok("Producto eliminado del carrito.");
        }


        [HttpPost("finalizar-compra/{idCliente}")]
        public IActionResult FinalizarCompra(int idCliente)
        {
            try
            {
                _carritoService.FinalizarCompra(idCliente);
                return Ok("Compra realizada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al finalizar la compra: {ex.Message}");
            }
        }


    }
}
