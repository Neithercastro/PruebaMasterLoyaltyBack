using Microsoft.AspNetCore.Mvc;

namespace PruebaMasterLoyalty.API.DTOs
{
    public class EditarProductoRequest
    {
        [FromForm]
        public int IdArticulo { get; set; }

        [FromForm]
        public string? Descripcion { get; set; }

        [FromForm]
        public int? Precio { get; set; }

        [FromForm]
        public int? Stock { get; set; }

        [FromForm]
        public bool? Estado { get; set; }

        [FromForm]
        public IFormFile? Imagen { get; set; }

    }
}
