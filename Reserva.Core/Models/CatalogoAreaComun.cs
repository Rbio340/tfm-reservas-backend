using System.Text.Json.Serialization;

namespace Reserva.Core.Models;

public partial class CatalogoAreaComun
{
    public int CatespId { get; set; }
    public string CatespNombre { get; set; } = null!;
    public int? EstId { get; set; }
    [JsonIgnore]
    public virtual ICollection<AreaComun> AreaComuns { get; set; } = new List<AreaComun>();
    public virtual Estado? Est { get; set; }
}