using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaMasterLoyalty.Data.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<CarritoCompra> CarritoCompras { get; set; }

    public virtual DbSet<CarritoComprasDetalle> CarritoComprasDetalles { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<VentasDetalle> VentasDetalles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo);

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.Imagen)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articulos_Tiendas");
        });

        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity.HasKey(e => e.IdCarritoCompras);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CarritoCompras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoCompras_Clientes");
        });

        modelBuilder.Entity<CarritoComprasDetalle>(entity =>
        {
            entity.HasKey(e => e.IdCarritoComprasDetalle);

            entity.ToTable("CarritoComprasDetalle");

            entity.Property(e => e.Producto)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.CarritoComprasDetalles)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoComprasDetalle_Articulos");

            entity.HasOne(d => d.IdCarritoComprasNavigation).WithMany(p => p.CarritoComprasDetalles)
                .HasForeignKey(d => d.IdCarritoCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoComprasDetalle_CarritoCompras");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.CarritoComprasDetalles)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoComprasDetalle_Tiendas");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Usuarios");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.IdTienda);

            entity.Property(e => e.Direccion)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tiendas_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.Property(e => e.FechaVenta).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Clientes");
        });

        modelBuilder.Entity<VentasDetalle>(entity =>
        {
            entity.HasKey(e => e.IdVentasDetalle);

            entity.ToTable("VentasDetalle");

            entity.Property(e => e.Producto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.VentasDetalles)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentasDetalle_Articulos");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentasDetalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentasDetalle_Ventas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
