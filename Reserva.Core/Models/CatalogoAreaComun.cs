using System;
using System.Collections.Generic;

namespace Reserva.Core.Models;

public partial class CatalogoAreaComun
{
    public int CatespId { get; set; }

    public string CatespNombre { get; set; } = null!;

    public virtual ICollection<AreaComun> AreaComuns { get; set; } = new List<AreaComun>();
}
