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
    public class TiendaService : ITiendaService
    {
        private readonly AppDbContext _context;
        private const int TamanoPagina = 3;

        public TiendaService(AppDbContext context)
        {
            _context = context;
        }

        //REGISTRAR NUEVA TIENDA
        public void RegistrarTienda(TiendaRegistroDTO dto)
        {
            if (_context.Usuarios.Any(u => u.Usuario1 == dto.Usuario))
                throw new Exception("El nombre de usuario ya está en uso.");
            if (_context.Tiendas.Any(u => u.Sucursal == dto.Sucursal))
                throw new Exception("Esa Sucursal ya está Registrada.");
            // 1. Insertar en Usuarios
            var nuevaTienda = new Usuario
            {
                Usuario1 = dto.Usuario,
                Password = dto.Password,
                TipoUsuario = "Tienda"
            };

            _context.Usuarios.Add(nuevaTienda);
            _context.SaveChanges();

            // 2. Insertar en Tienda usando el Id del usuario insertado
            var tienda = new Tienda
            {
                IdUsuario = nuevaTienda.IdUsuario,
                Sucursal = dto.Sucursal,
                Direccion = dto.Direccion
            };

            _context.Tiendas.Add(tienda);
            _context.SaveChanges();
        }

        // SELECT TIENDAS
        public PaginacionResponse<TiendaDTO> ListarTiendas(int pagina)
        {
            var query = _context.Tiendas
                .Where(t => t.Articulos.Any(a => a.Estado == true)) // ✅ condición correcta
                .AsQueryable();

            var total = query.Count();

            var datos = query
                .Skip((pagina - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .Select(t => new TiendaDTO
                {
                    IdTienda = t.IdTienda,
                    Sucursal = t.Sucursal,
                    Direccion = t.Direccion
                })
                .ToList();

            return new PaginacionResponse<TiendaDTO>
            {
                Datos = datos,
                TotalRegistros = total,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)total / TamanoPagina)
            };
        }

        //OBTENER TIENDA POR ID USUARIO
        public TiendaDTO? ObtenerTiendaPorUsuario(int idUsuario)
        {
            var tienda = _context.Tiendas
                .Where(t => t.IdUsuario == idUsuario)
                .Select(t => new TiendaDTO
                {
                    IdTienda = t.IdTienda,
                    Sucursal = t.Sucursal,
                    Direccion = t.Direccion
                })
                .FirstOrDefault();

            return tienda;
        }




    }
}
