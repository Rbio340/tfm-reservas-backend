using System.Text.Json.Serialization;

namespace Reserva.Core.Models;

public partial class AreaComun
{
    public int EspId { get; set; }

    public int? CatespId { get; set; }

    public int? EstId { get; set; }

    public string EspNombre { get; set; } = null!;

    [JsonIgnore] 
    public virtual CatalogoAreaComun? Catesp { get; set; }

    [JsonIgnore] 
    public virtual Estado? Est { get; set; }

    [JsonIgnore] 
    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
