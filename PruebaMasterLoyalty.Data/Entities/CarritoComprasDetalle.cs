using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class CarritoComprasDetalle
{
    public int IdCarritoComprasDetalle { get; set; }

    public int IdCarritoCompras { get; set; }

    public int IdTienda { get; set; }

    public int IdArticulo { get; set; }

    public string Producto { get; set; } = null!;

    public int Cantidad { get; set; }

    public int Precio { get; set; }

    public int Subtotal { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    public virtual CarritoCompra IdCarritoComprasNavigation { get; set; } = null!;

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;
}
