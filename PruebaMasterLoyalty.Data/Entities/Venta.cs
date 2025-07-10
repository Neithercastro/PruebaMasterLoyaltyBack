using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaVenta { get; set; }

    public int Total { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<VentasDetalle> VentasDetalles { get; set; } = new List<VentasDetalle>();
}
