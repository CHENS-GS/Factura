using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Factura.Models;

public partial class BdfacturaContext : DbContext
{
    public BdfacturaContext()
    {
    }

    public BdfacturaContext(DbContextOptions<BdfacturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BICHENSO;Database=BDFACTURA; Integrated security=true;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura).HasName("PK__DetalleF__DB5F4631783CF878");

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.CodigoProducto).HasMaxLength(50);
            entity.Property(e => e.Igv)
                .HasDefaultValue(0.18m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IGV");
            entity.Property(e => e.ImporteTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleFa__Codig__47DBAE45");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleFa__IdFac__46E78A0C");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__50E7BAF1E0D0FF61");

            entity.ToTable("Factura");

            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.MontoIgv)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoIGV");
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("RUC");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892109A749CE6");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BD29C6E9E2");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasMaxLength(50);
            entity.Property(e => e.Igv)
                .HasDefaultValue(0.18m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IGV");
            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__IdFactura__4BAC3F29");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__IdProduct__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
