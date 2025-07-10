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


    }
}
