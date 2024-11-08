﻿namespace Reserva.Core.Models;

public partial class Estado
{
    public int EstId { get; set; }
    public string EstNombre { get; set; } = null!;
    public virtual ICollection<AreaComun> AreaComuns { get; set; } = new List<AreaComun>();
    public virtual ICollection<CatalogoAreaComun> CatalogoAreaComuns { get; set; } = new List<CatalogoAreaComun>();
    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}