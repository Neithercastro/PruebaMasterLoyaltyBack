using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public List<VentaDetalleDTO> Detalles { get; set; }

    }
}
