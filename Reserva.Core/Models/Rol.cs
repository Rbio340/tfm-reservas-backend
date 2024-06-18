using System.Text.Json.Serialization;

namespace Reserva.Core.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public int? EstId { get; set; }
    public int? EstId1 { get; set; }

    [JsonIgnore]
    public virtual Estado? Est { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
