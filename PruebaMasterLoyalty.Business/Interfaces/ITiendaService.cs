﻿using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Interfaces
{
    public interface ITiendaService
    {
        void RegistrarTienda(TiendaRegistroDTO dto);
        PaginacionResponse<TiendaDTO> ListarTiendas(int pagina);
        TiendaDTO? ObtenerTiendaPorUsuario(int idUsuario);

    }
}
