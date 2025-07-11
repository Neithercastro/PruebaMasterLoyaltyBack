using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface IClienteService
    {
        void RegistrarCliente(ClienteRegistroDTO dto);
        ClienteDTO? ObtenerClientePorUsuario(int idUsuario);

    }
}
