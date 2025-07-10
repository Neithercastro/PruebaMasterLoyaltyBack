using Microsoft.AspNetCore.Mvc;

namespace PruebaMasterLoyalty.API.DTOs
{
    public class ImagenDTO
    {
        [FromForm]
        public IFormFile Archivo { get; set; }

    }
}
