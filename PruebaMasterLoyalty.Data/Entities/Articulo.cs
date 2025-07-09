using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public int IdTienda { get; set; }

    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Precio { get; set; }

    public string Imagen { get; set; } = null!;

    public int Stock { get; set; }

    public int Estado { get; set; }

    public DateOnly FechaAlta { get; set; }

    public virtual ICollection<CarritoComprasDetalle> CarritoComprasDetalles { get; set; } = new List<CarritoComprasDetalle>();

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;
}
