﻿using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public int IdTienda { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Precio { get; set; }

    public string Imagen { get; set; } = null!;

    public int Stock { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaAlta { get; set; }

    public virtual ICollection<CarritoComprasDetalle> CarritoComprasDetalles { get; set; } = new List<CarritoComprasDetalle>();

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;

    public virtual ICollection<VentasDetalle> VentasDetalles { get; set; } = new List<VentasDetalle>();
}
