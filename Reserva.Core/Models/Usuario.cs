using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reserva.Core.Models;

public partial class Usuario
{
    public int UsuId { get; set; }

    public int? EstId { get; set; }

    public string UsuNombre { get; set; } = null!;

    public string UsuPassword { get; set; } = null!;

    public int? IdRol { get; set; }
    public string? RolNombre => IdRolNavigation.Nombre;

    [JsonIgnore]
    public virtual Estado? Est { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Rol? IdRolNavigation { get; set; }

}
