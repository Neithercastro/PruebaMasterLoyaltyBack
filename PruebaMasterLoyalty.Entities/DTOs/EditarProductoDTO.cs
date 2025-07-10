using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class EditarProductoDTO
    {
        public int IdArticulo { get; set; }

        public string? Descripcion { get; set; }
        public int? Precio { get; set; }
        public int? Stock { get; set; }
        public bool? Estado { get; set; }
        public string? Imagen { get; set; } // Ruta o nombre del archivo subido
    }
}
