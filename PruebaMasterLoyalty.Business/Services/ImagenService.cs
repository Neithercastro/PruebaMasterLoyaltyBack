using Microsoft.AspNetCore.Http;
using PruebaMasterLoyalty.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Services
{
    public class ImagenService : IImagenService
    {
        private readonly IPathProvider _pathProvider;

        public ImagenService(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public async Task<string> GuardarImagenAsync(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
                throw new Exception("Imagen no válida.");

            var nombreArchivo = Guid.NewGuid() + Path.GetExtension(imagen.FileName);
            var rutaCarpeta = _pathProvider.GetUploadsPath();

            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            return $"/uploads/{nombreArchivo}";
        }

    }
}
