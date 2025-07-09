using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class TiendaRegistroDTO
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
    }
}
