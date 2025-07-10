using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMasterLoyalty.API.DTOs;
using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Business.Services;
using PruebaMasterLoyalty.Entities.DTOs;

namespace PruebaMasterLoyalty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloservice;
        private readonly IImagenService _imagenService;


        public ArticuloController(ArticuloService service, IImagenService imagenService)
        {
            _articuloservice = service;
            _imagenService = imagenService;
        }

        //ENDPOINT ALTA PRODUCTO
        [HttpPost("AltaArticulo")]
        public async Task<IActionResult> RegistrarProducto([FromForm] RegistroProductoRequest request)
        {
            try
            {
                string? rutaImagen = null;

                if (request.Imagen != null && request.Imagen.Length > 0)
                {
                    rutaImagen = await _imagenService.GuardarImagenAsync(request.Imagen);
                }

                var dto = new RegistroProductoDTO
                {
                    IdTienda = request.IdTienda,
                    Codigo = request.Codigo,
                    Descripcion = request.Descripcion,
                    Precio = request.Precio,
                    Stock = request.Stock,
                    Estado = request.Estado,
                    FechaAlta = DateTime.Now,
                    Imagen = rutaImagen
                };

                _articuloservice.RegistrarProducto(dto);

                return Ok("Producto registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar el producto: {ex.Message}");
            }
        }

        //ENDPOINT UPDATE PRODUCTO
        [HttpPost("EditarArticulo")]
        public async Task<IActionResult> EditarProducto([FromForm] EditarProductoRequest request)
        {
            try
            {
                string? rutaImagen = null;

                if (request.Imagen != null && request.Imagen.Length > 0)
                {
                    rutaImagen = await _imagenService.GuardarImagenAsync(request.Imagen);
                }

                var dto = new EditarProductoDTO
                {
                    IdArticulo = request.IdArticulo,
                    Descripcion = request.Descripcion,
                    Precio = request.Precio,
                    Stock = request.Stock,
                    Estado = request.Estado,
                    Imagen = rutaImagen
                };

                _articuloservice.EditarProducto(dto);

                return Ok("Articulo actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el producto: {ex.Message}");
            }


        }

        //OBTENER TODOS LOS ARTICULOS
        [HttpGet("BuscarTodos")]
        public IActionResult ObtenerTodos([FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = _articuloservice.ListarArticulos(pagina);
                return Ok(resultado);
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Error al buscar productos: {ex.Message}");

            }
           
        }

        //OBTENER ARTICULOS X TIENDA (CLIENTES)
        [HttpGet("Cliente/BuscarPorTienda/{idTienda}")]
        public IActionResult ObtenerPorTienda(int idTienda, [FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = _articuloservice.ListarArticulosPorTienda(idTienda, pagina);
                return Ok(resultado);
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Error al buscar el productos por tienda: {ex.Message}");

            }
           
        }

        // Para tiendas (admin)
        [HttpGet("Admin/Tienda/{idTienda}")]
        public IActionResult ObtenerTodosPorTienda(int idTienda, [FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = _articuloservice.ListarTodosArticulosPorTienda(idTienda, pagina);
                return Ok(resultado);
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Error al buscar productos: {ex.Message}");

            }
            
        }


    }
}
