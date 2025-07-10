using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class VentasDetalle
{
    public int IdVentasDetalle { get; set; }

    public int IdVenta { get; set; }

    public int IdArticulo { get; set; }

    public string Producto { get; set; } = null!;

    public int Cantidad { get; set; }

    public int Precio { get; set; }

    public int Subtotal { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
