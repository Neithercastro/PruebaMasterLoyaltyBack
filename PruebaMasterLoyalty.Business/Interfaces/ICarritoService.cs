using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface ICarritoService
    {
        CarritoDTO ObtenerCarritoPorCliente(int idCliente);
        void AgregarProducto(AgregarProductoCarritoDTO dto);
        void ActualizarCantidad(ActualizarCantidadCarritoDTO dto);
        void EliminarProducto(EliminarProductoCarritoDTO dto);
        void FinalizarCompra(int idCliente);

        

    }

}

