using Microsoft.EntityFrameworkCore;
using Reserva.Core.Dto;
using Reserva.Core.Models;

namespace Reserva.Repository.Context;

public partial class ReservaContext : DbContext
{
    public ReservaContext()
    {
    }

    public ReservaContext(DbContextOptions<ReservaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaComun> AreaComuns { get; set; }

    public virtual DbSet<CatalogoAreaComun> CatalogoAreaComuns { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Configuracion> Configuracion { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public DbSet<AreaComunDto> AreaComunDtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=db-demo-unir.ckhnlwuydbta.us-east-1.rds.amazonaws.com;Database=Reservas;Uid=admin;Pwd=123456789;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaComun>(entity =>
        {
            entity.HasKey(e => e.EspId).HasName("PRIMARY");

            entity.ToTable("AREA_COMUN");

            entity.HasIndex(e => e.CatespId, "FK_ESPACIO_TIENE_CATALOGO_DE_ESPACIO");

            entity.HasIndex(e => e.EstId, "FK_ESPACIO_TIENE_ESTADO");

            entity.Property(e => e.EspId).HasColumnName("ESP_ID");
            entity.Property(e => e.CatespId).HasColumnName("CATESP_ID");
            entity.Property(e => e.EspNombre)
                .HasMaxLength(90)
                .HasColumnName("ESP_NOMBRE");
            entity.Property(e => e.EstId).HasColumnName("EST_ID");

            entity.HasOne(d => d.Catesp).WithMany(p => p.AreaComuns)
                .HasForeignKey(d => d.CatespId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ESPACIO_TIENE_CATALOGO_DE_ESPACIO");

            entity.HasOne(d => d.Est).WithMany(p => p.AreaComuns)
                .HasForeignKey(d => d.EstId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ESPACIO_TIENE_ESTADO");
        });

        modelBuilder.Entity<CatalogoAreaComun>(entity =>
        {
            entity.HasKey(e => e.CatespId).HasName("PRIMARY");

            entity.ToTable("CATALOGO_AREA_COMUN");

            entity.Property(e => e.CatespId).HasColumnName("CATESP_ID");
            entity.Property(e => e.CatespNombre)
                .HasMaxLength(40)
                .HasColumnName("CATESP_NOMBRE");
            entity.Property(e => e.EstId).HasColumnName("EST_ID");

            entity.HasOne(d => d.Est).WithMany(p => p.CatalogoAreaComuns)
                .HasForeignKey(d => d.EstId)
                .HasConstraintName("fk_estado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstId).HasName("PRIMARY");

            entity.ToTable("ESTADO");

            entity.Property(e => e.EstId).HasColumnName("EST_ID");
            entity.Property(e => e.EstNombre)
                .HasMaxLength(40)
                .HasColumnName("EST_NOMBRE");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ResId).HasName("PRIMARY");

            entity.ToTable("RESERVA");

            entity.HasIndex(e => e.EspId, "FK_AREA_COMUN_ESTA_EN_RESERVA");

            entity.HasIndex(e => e.UsuId, "FK_USUARIO_HACE_RESERVA");

            entity.HasIndex(e => e.EstId, "fk_estado_reserva");

            entity.Property(e => e.ResId).HasColumnName("RES_ID");
            entity.Property(e => e.EspId).HasColumnName("ESP_ID");
            entity.Property(e => e.EstId).HasColumnName("EST_ID");
            entity.Property(e => e.ResFecha)
                .HasColumnType("datetime")
                .HasColumnName("RES_FECHA");
            entity.Property(e => e.ResFechaFin)
                .HasColumnType("datetime")
                .HasColumnName("RES_FECHA_FIN");
            entity.Property(e => e.ResNumPersonas).HasColumnName("RES_NUM_PERSONAS");
            entity.Property(e => e.UsuId).HasColumnName("USU_ID");

            entity.HasOne(d => d.Esp).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EspId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_AREA_COMUN_ESTA_EN_RESERVA");

            entity.HasOne(d => d.Est).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstId)
                .HasConstraintName("fk_estado_reserva");

            entity.HasOne(d => d.Usu).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_USUARIO_HACE_RESERVA");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuId).HasName("PRIMARY");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.EstId, "FK_USUARIO_TIENE_ESTADO");

            entity.HasIndex(e => e.IdRol, "fk_usuario_rol");

            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
            entity.Property(e => e.EstId).HasColumnName("EST_ID");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

            entity.Property(e => e.UsuNombre)
                .HasMaxLength(90)
                .HasColumnName("USU_NOMBRE");
            entity.Property(e => e.UsuPassword)
                .HasMaxLength(250)
                .HasColumnName("USU_PASSWORD");

            entity.HasOne(d => d.Est).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EstId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_USUARIO_TIENE_ESTADO");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_usuario_rol");
        });

        modelBuilder.Entity<AreaComunDto>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.ConfigId).HasName("PRIMARY");

            entity.ToTable("CONFIGURACION");

            entity.Property(e => e.ConfigId).HasColumnName("CONFIG_ID");
            entity.Property(e => e.EspId).HasColumnName("ESP_ID");

            entity.Property(e => e.ConfigId).HasColumnName("CONFIG_ID");
            entity.Property(e => e.EspId).HasColumnName("ESP_ID");
            entity.Property(e => e.FecMaxReserva).HasColumnName("FEC_MAX_RESERVA");
            entity.Property(e => e.FecMinReserva).HasColumnName("FEC_MIN_RESERVA");
            entity.Property(e => e.NumMaxPersona).HasColumnName("NUM_MAX_PERSONA");
            entity.Property(e => e.NumMinPersona).HasColumnName("NUM_MIN_PERSONA");
            entity.Property(e => e.TiempMaxReserva)
                .HasColumnType("time")
                .HasColumnName("TIEMP_MAX_RESERVA");
            entity.Property(e => e.TiempMinReserva)
                .HasColumnType("time")
                .HasColumnName("TIEMP_MIN_RESERVA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        
}
