using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class RegistroProductoDTO
    {
       public int IdTienda {  get; set; }
       public string Codigo { get; set; }
        public string Descripcion {  get; set; }
        public int Precio { get; set; }
        public string Imagen {  get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}
