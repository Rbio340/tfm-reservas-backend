using System;
using System.Collections.Generic;

namespace Reserva.Core.Models;

public partial class Reservas
{
    public int ResId { get; set; }

    public int? UsuId { get; set; }

    public int? EspId { get; set; }

    public DateTime ResFecha { get; set; }

    public DateTime ResFechaFin { get; set; }

    public int ResNumPersonas { get; set; }

    public virtual AreaComun? Esp { get; set; }

    public virtual Usuario? Usu { get; set; }
}
