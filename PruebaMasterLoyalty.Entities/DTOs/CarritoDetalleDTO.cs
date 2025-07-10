using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class CarritoDetalleDTO
    {
        public int IdCarritoComprasDetalle { get; set; }
        public int IdArticulo { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string Imagen { get; set; }
    }
}
