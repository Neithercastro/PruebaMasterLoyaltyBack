using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class CarritoDTO
    {
        public int IdCarritoCompras { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public List<CarritoDetalleDTO> Detalles { get; set; }

    }
}
