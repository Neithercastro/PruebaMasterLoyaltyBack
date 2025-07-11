using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class ArticuloDTO
    {
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public int IdTienda { get; set; }
        public bool Estado { get; set; }
    }
}
