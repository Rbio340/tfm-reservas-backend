using System.Text.Json.Serialization;

namespace Reserva.Core.Models;

public partial class Reservas
{
    public int ResId { get; set; }
    public int? UsuId { get; set; }
    public int? EspId { get; set; }
    public DateTime? ResFecha { get; set; }
    public int ResNumPersonas { get; set; }
    public int? EstId { get; set; }
    public TimeSpan? HoraIni { get; set; }
    public TimeSpan? HoraFinal { get; set; }
    [JsonIgnore]
    public virtual AreaComun? Esp { get; set; }
    [JsonIgnore]
    public virtual Estado? Est { get; set; }
    [JsonIgnore]
    public virtual Usuario? Usu { get; set; }
    public string? EspNombre => Esp?.EspNombre;
    public string? UsuNombre => Usu?.UsuNombre;
}