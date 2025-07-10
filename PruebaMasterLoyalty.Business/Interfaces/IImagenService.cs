using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface IImagenService
    {
        Task<string> GuardarImagenAsync(IFormFile imagen);
    }
}
