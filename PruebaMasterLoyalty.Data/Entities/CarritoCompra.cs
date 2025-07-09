using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class CarritoCompra
{
    public int IdCarritoCompras { get; set; }

    public int IdCliente { get; set; }

    public int Total { get; set; }

    public virtual ICollection<CarritoComprasDetalle> CarritoComprasDetalles { get; set; } = new List<CarritoComprasDetalle>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
