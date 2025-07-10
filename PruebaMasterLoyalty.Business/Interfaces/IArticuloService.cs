using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface IArticuloService
    {

        PaginacionResponse<ArticuloDTO> ListarArticulos(int pagina);
        PaginacionResponse<ArticuloDTO> ListarArticulosPorTienda(int idTienda, int pagina);
        PaginacionResponse<ArticuloDTO> ListarTodosArticulosPorTienda(int idTienda, int pagina);
        void RegistrarProducto(RegistroProductoDTO dto);
        void EditarProducto(EditarProductoDTO dto);
       

    }
}
