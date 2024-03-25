using System;
using System.Collections.Generic;

namespace Reserva.Core.Models;

public partial class Estado
{
    public int EstId { get; set; }

    public string EstNombre { get; set; } = null!;

    public virtual ICollection<AreaComun> AreaComuns { get; set; } = new List<AreaComun>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
