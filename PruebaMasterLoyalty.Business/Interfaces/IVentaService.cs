using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface IVentaService
    {
        PaginacionResponse<VentaDTO> ObtenerHistorialCompras(int idCliente, int pagina);

    }
}
