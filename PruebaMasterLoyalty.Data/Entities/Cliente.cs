using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<CarritoCompra> CarritoCompras { get; set; } = new List<CarritoCompra>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
