using System;
using System.Collections.Generic;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Tienda> Tienda { get; set; } = new List<Tienda>();
}
