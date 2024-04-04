namespace Reserva.Core.Models;

public partial class AreaComun
{
    public int EspId { get; set; }

    public int? CatespId { get; set; }

    public int? EstId { get; set; }

    public string EspNombre { get; set; } = null!;

    public virtual CatalogoAreaComun? Catesp { get; set; }

    public virtual Estado? Est { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
