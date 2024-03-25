﻿using Microsoft.EntityFrameworkCore;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=reserva;Uid=root;Pwd=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaComun>(entity =>
        {
            entity.HasKey(e => e.EspId).HasName("PRIMARY");

            entity.ToTable("area_comun");

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

            entity.ToTable("catalogo_area_comun");

            entity.Property(e => e.CatespId).HasColumnName("CATESP_ID");
            entity.Property(e => e.CatespNombre)
                .HasMaxLength(40)
                .HasColumnName("CATESP_NOMBRE");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstId).HasName("PRIMARY");

            entity.ToTable("estado");

            entity.Property(e => e.EstId).HasColumnName("EST_ID");
            entity.Property(e => e.EstNombre)
                .HasMaxLength(40)
                .HasColumnName("EST_NOMBRE");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ResId).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.EspId, "FK_AREA_COMUN_ESTA_EN_RESERVA");

            entity.HasIndex(e => e.UsuId, "FK_USUARIO_HACE_RESERVA");

            entity.Property(e => e.ResId).HasColumnName("RES_ID");
            entity.Property(e => e.EspId).HasColumnName("ESP_ID");
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

            entity.HasOne(d => d.Usu).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_USUARIO_HACE_RESERVA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuId).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.EstId, "FK_USUARIO_TIENE_ESTADO");

            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
            entity.Property(e => e.EstId).HasColumnName("EST_ID");
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}