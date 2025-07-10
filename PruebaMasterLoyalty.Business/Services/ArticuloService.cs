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
    public class ArticuloService : IArticuloService
    {
        private readonly AppDbContext _context;
        private const int TamanoPagina = 10;

        public ArticuloService(AppDbContext context)
        {
            _context = context;
        }
        //REGISTRAR NUEVO PRODUCTO
        public void RegistrarProducto(RegistroProductoDTO dto)
        {
            //Insertamos en la tabla Articulos
            var articulo = new Articulo
            {
                IdTienda = dto.IdTienda,
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Imagen = dto.Imagen,
                Stock = dto.Stock,
                Estado = dto.Estado,
                FechaAlta = DateTime.Now
            };

            _context.Articulos.Add(articulo);
            _context.SaveChanges();
        }

        //MODIFICAR PRODUCTO
        public void EditarProducto(EditarProductoDTO dto)
        {
            var producto = _context.Articulos.FirstOrDefault(a => a.IdArticulo == dto.IdArticulo);
            if (producto == null)
                throw new Exception("Producto no encontrado.");

            if (!string.IsNullOrEmpty(dto.Descripcion))
                producto.Descripcion = dto.Descripcion;

            if (dto.Precio.HasValue)
                producto.Precio = dto.Precio.Value;

            if (dto.Stock.HasValue)
                producto.Stock = dto.Stock.Value;

            if (dto.Estado.HasValue)
                producto.Estado = dto.Estado.Value;

            if (!string.IsNullOrEmpty(dto.Imagen))
                producto.Imagen = dto.Imagen;

            _context.SaveChanges();
        }

        // SELECT ARTICULOS
        public PaginacionResponse<ArticuloDTO> ListarArticulos(int pagina)
        {
         
            var query = _context.Articulos
                .Where(a => a.Estado == true)
                .AsQueryable();
            var total = query.Count();

            var datos = query
                .Skip((pagina - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .Select(a => new ArticuloDTO
                {
                    IdArticulo = a.IdArticulo,
                    Descripcion = a.Descripcion,
                    Precio = a.Precio,
                    Imagen = a.Imagen,
                    IdTienda = a.IdTienda
                })
                .ToList();

            return new PaginacionResponse<ArticuloDTO>
            {
                Datos = datos,
                TotalRegistros = total,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)total / TamanoPagina)
            };
        }

        //SELECT ARTICULOS X TIENDA
        public PaginacionResponse<ArticuloDTO> ListarArticulosPorTienda(int idTienda, int pagina)
        {
            var query = _context.Articulos.Where(a => a.IdTienda == idTienda && a.Estado == true);
            var total = query.Count();

            var datos = query
                .Skip((pagina - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .Select(a => new ArticuloDTO
                {
                    IdArticulo = a.IdArticulo,
                    Descripcion = a.Descripcion,
                    Precio = a.Precio,
                    Imagen = a.Imagen,
                    IdTienda = a.IdTienda
                })
                .ToList();

            return new PaginacionResponse<ArticuloDTO>
            {
                Datos = datos,
                TotalRegistros = total,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)total / TamanoPagina)
            };
        }

        public PaginacionResponse<ArticuloDTO> ListarTodosArticulosPorTienda(int idTienda, int pagina)
        {
            var query = _context.Articulos.Where(a => a.IdTienda == idTienda);
            var total = query.Count();

            var datos = query
                .Skip((pagina - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .Select(a => new ArticuloDTO
                {
                    IdArticulo = a.IdArticulo,
                    Descripcion = a.Descripcion,
                    Precio = a.Precio,
                    Imagen = a.Imagen,
                    IdTienda = a.IdTienda
                })
                .ToList();

            return new PaginacionResponse<ArticuloDTO>
            {
                Datos = datos,
                TotalRegistros = total,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)total / TamanoPagina)
            };
        }
    }
}
