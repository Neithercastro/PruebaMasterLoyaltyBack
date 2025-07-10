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
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public void RegistrarCliente(ClienteRegistroDTO dto)
        {
            if (_context.Usuarios.Any(u => u.Usuario1 == dto.Usuario))
                throw new Exception("El nombre de usuario ya está en uso.");
            // 1. Insertar en Usuarios
            var nuevoUsuario = new Usuario
            {
             
                Usuario1 = dto.Usuario,
                Password = dto.Password,
                TipoUsuario = "Cliente"
            };

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

            // 2. Insertar en Clientes usando el Id del usuario insertado
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                IdUsuario = nuevoUsuario.IdUsuario,
                Apellidos = dto.Apellidos,
                Direccion = dto.Direccion
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
