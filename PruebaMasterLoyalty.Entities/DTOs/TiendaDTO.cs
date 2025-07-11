using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class TiendaDTO
    {
        public int IdTienda { get; set; }
        public string Sucursal { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }
}
