using System;
using System.Collections.Generic;

namespace Reserva.Core.Models;

public partial class Usuario
{
    public int UsuId { get; set; }

    public int? EstId { get; set; }

    public string UsuNombre { get; set; } = null!;

    public string UsuPassword { get; set; } = null!;

    public virtual Estado? Est { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
