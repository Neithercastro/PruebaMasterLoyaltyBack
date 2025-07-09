using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Tienda
{
    public int IdTienda { get; set; }

    public int IdUsuario { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual ICollection<CarritoComprasDetalle> CarritoComprasDetalles { get; set; } = new List<CarritoComprasDetalle>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
