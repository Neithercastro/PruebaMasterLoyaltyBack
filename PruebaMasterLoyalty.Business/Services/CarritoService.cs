using PruebaMasterLoyalty.Business.Interfaces;
using PruebaMasterLoyalty.Data.Entities;
using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly AppDbContext _context;

        public CarritoService(AppDbContext context)
        {
            _context = context;
        }

        public void AgregarProducto(AgregarProductoCarritoDTO dto)
        {
            var carrito = _context.CarritoCompras.FirstOrDefault(c => c.IdCliente == dto.IdCliente);

            if (carrito == null)
            {
                carrito = new CarritoCompra
                {
                    IdCliente = dto.IdCliente,
                    Total = 0
                };
                _context.CarritoCompras.Add(carrito);
                _context.SaveChanges();
            }

            var detalle = _context.CarritoComprasDetalles
                .FirstOrDefault(d => d.IdCarritoCompras == carrito.IdCarritoCompras && d.IdArticulo == dto.IdArticulo);

            if (detalle != null)
            {
                detalle.Cantidad += dto.Cantidad;
                detalle.Subtotal = detalle.Cantidad * detalle.Precio;
            }
            else
            {
                detalle = new CarritoComprasDetalle
                {
                    IdCarritoCompras = carrito.IdCarritoCompras,
                    IdArticulo = dto.IdArticulo,
                    IdTienda = dto.IdTienda,
                    Producto = dto.Producto,
                    Precio = dto.Precio,
                    Cantidad = dto.Cantidad,
                    Subtotal = dto.Precio * dto.Cantidad
                };
                _context.CarritoComprasDetalles.Add(detalle);
            }

            carrito.Total = _context.CarritoComprasDetalles
                .Where(d => d.IdCarritoCompras == carrito.IdCarritoCompras)
                .Sum(d => d.Subtotal);

            _context.SaveChanges();
        }

        public void ActualizarCantidad(ActualizarCantidadCarritoDTO dto)
        {
            var detalle = _context.CarritoComprasDetalles.FirstOrDefault(d => d.IdCarritoComprasDetalle == dto.IdCarritoComprasDetalle);
            if (detalle == null) throw new Exception("Detalle no encontrado.");

            detalle.Cantidad = dto.NuevaCantidad;
            detalle.Subtotal = detalle.Cantidad * detalle.Precio;

            var carrito = _context.CarritoCompras.FirstOrDefault(c => c.IdCarritoCompras == detalle.IdCarritoCompras);
            carrito.Total = _context.CarritoComprasDetalles
                .Where(d => d.IdCarritoCompras == carrito.IdCarritoCompras)
                .Sum(d => d.Subtotal);

            _context.SaveChanges();
        }

        public void EliminarProducto(EliminarProductoCarritoDTO dto)
        {
            var detalle = _context.CarritoComprasDetalles.FirstOrDefault(d => d.IdCarritoComprasDetalle == dto.IdCarritoComprasDetalle);
            if (detalle == null) throw new Exception("Detalle no encontrado.");

            var carrito = _context.CarritoCompras.FirstOrDefault(c => c.IdCarritoCompras == detalle.IdCarritoCompras);

            _context.CarritoComprasDetalles.Remove(detalle);
            _context.SaveChanges();

            carrito.Total = _context.CarritoComprasDetalles
                .Where(d => d.IdCarritoCompras == carrito.IdCarritoCompras)
                .Sum(d => d.Subtotal);

            _context.SaveChanges();
        }

        public CarritoDTO ObtenerCarritoPorCliente(int idCliente)
        {
            var carrito = _context.CarritoCompras
                .FirstOrDefault(c => c.IdCliente == idCliente);

            if (carrito == null)
            {
                return new CarritoDTO
                {
                    IdCliente = idCliente,
                    Total = 0,
                    Detalles = new List<CarritoDetalleDTO>()
                };
            }

            var detalles = _context.CarritoComprasDetalles
                .Where(d => d.IdCarritoCompras == carrito.IdCarritoCompras)
                .Select(d => new CarritoDetalleDTO
                {
                    IdCarritoComprasDetalle = d.IdCarritoComprasDetalle,
                    IdArticulo = d.IdArticulo,
                    Producto = d.Producto,
                    Precio = d.Precio,
                    Cantidad = d.Cantidad,
                    Subtotal = d.Subtotal,
                    Imagen = _context.Articulos
                        .Where(a => a.IdArticulo == d.IdArticulo)
                        .Select(a => a.Imagen)
                        .FirstOrDefault()
                })
                .ToList();

            return new CarritoDTO
            {
                IdCarritoCompras = carrito.IdCarritoCompras,
                IdCliente = carrito.IdCliente,
                Total = carrito.Total,
                Detalles = detalles
            };
        }


        public void FinalizarCompra(int idCliente)
        {
            var carrito = _context.CarritoCompras
                .FirstOrDefault(c => c.IdCliente == idCliente);

            if (carrito == null)
                throw new Exception("El carrito está vacío.");

            var detalles = _context.CarritoComprasDetalles
                .Where(d => d.IdCarritoCompras == carrito.IdCarritoCompras)
                .ToList();

            if (!detalles.Any())
                throw new Exception("No hay productos en el carrito.");

            // Crear la venta
            var venta = new Venta
            {
                IdCliente = idCliente,
                FechaVenta = DateTime.Now,
                Total = carrito.Total
            };
            _context.Ventas.Add(venta);
            _context.SaveChanges(); // Para obtener el IdVenta

            // Crear detalles de la venta
            foreach (var item in detalles)
            {
                var detalleVenta = new VentasDetalle
                {
                    IdVenta = venta.IdVenta,
                    IdArticulo = item.IdArticulo,
                    Producto = item.Producto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Subtotal = item.Subtotal
                };
                _context.VentasDetalles.Add(detalleVenta);
            }

            // Limpiar el carrito
            _context.CarritoComprasDetalles.RemoveRange(detalles);
            carrito.Total = 0;

            _context.SaveChanges();
        }


    }
}
