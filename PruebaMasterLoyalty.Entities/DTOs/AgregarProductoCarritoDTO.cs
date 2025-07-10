using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class AgregarProductoCarritoDTO
    {
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int IdTienda { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
