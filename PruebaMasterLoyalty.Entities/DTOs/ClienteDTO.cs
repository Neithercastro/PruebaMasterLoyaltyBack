using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Direccion { get; set; }
    }
}
