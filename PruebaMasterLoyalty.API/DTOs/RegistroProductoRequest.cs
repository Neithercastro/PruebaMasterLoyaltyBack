using Microsoft.AspNetCore.Mvc;
using System;

namespace PruebaMasterLoyalty.API.DTOs
{
    public class RegistroProductoRequest
    {
        [FromForm]
        public int IdTienda { get; set; }

        [FromForm]
        public string Codigo { get; set; }

        [FromForm]
        public string Descripcion { get; set; }

        [FromForm]
        public int Precio { get; set; }

        [FromForm]
        public int Stock { get; set; }

        [FromForm]
        public bool Estado { get; set; }

        [FromForm]
        public DateTime FechaAlta { get; set; }

        [FromForm]
        public IFormFile? Imagen { get; set; }

    }
}
