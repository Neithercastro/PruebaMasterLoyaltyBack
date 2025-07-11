using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Entities.DTOs
{
    public class AuthResponseDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public string TipoUsuario { get; set; }
    }
}
