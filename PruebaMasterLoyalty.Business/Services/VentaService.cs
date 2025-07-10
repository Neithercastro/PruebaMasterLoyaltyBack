using Microsoft.EntityFrameworkCore;
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
    public class VentaService : IVentaService
    {
        private readonly AppDbContext _context;
        private const int TamanoPagina = 10;

        public VentaService(AppDbContext context)
        {
            _context = context;
        }
        public PaginacionResponse<VentaDTO> ObtenerHistorialCompras(int idCliente, int pagina)
        {
            var query = _context.Ventas
                .Where(v => v.IdCliente == idCliente)
                .OrderByDescending(v => v.FechaVenta);

            var total = query.Count();

            var ventas = query
                .Skip((pagina - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            var resultado = ventas.Select(venta => new VentaDTO
            {
                IdVenta = venta.IdVenta,
                FechaVenta = venta.FechaVenta,
                Total = venta.Total,
                Detalles = _context.VentasDetalles
                    .Where(d => d.IdVenta == venta.IdVenta)
                    .Select(d => new VentaDetalleDTO
                    {
                        Producto = d.Producto,
                        Cantidad = d.Cantidad,
                        Precio = d.Precio,
                        Subtotal = d.Subtotal
                    })
                    .ToList()
            }).ToList();

            return new PaginacionResponse<VentaDTO>
            {
                Datos = resultado,
                TotalRegistros = total,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)total / TamanoPagina)
            };
        }

    }
}
