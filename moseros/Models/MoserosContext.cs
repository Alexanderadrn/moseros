using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace moseros.Models;

public partial class MoserosContext : DbContext
{
    public MoserosContext()
    {
    }

    public MoserosContext(DbContextOptions<MoserosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amante> Amantes { get; set; }

    public virtual DbSet<Mosa> Mosas { get; set; }

    public virtual DbSet<RelacionAmanteMosa> RelacionAmanteMosas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S78SCGN;Database=moseros;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__amantes__3214EC27B04D805F");

            entity.ToTable("amantes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Algo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("algo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Mosa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mosas__3214EC27491CC511");

            entity.ToTable("mosas");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Algo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("algo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Edad)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<RelacionAmanteMosa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Relacion__3214EC27FAB9770D");

            entity.ToTable("Relacion_Amante_Mosa");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdAmamteNavigation).WithMany(p => p.RelacionAmanteMosas)
                .HasForeignKey(d => d.IdAmamte)
                .HasConstraintName("FK__Relacion___IdAma__59FA5E80");

            entity.HasOne(d => d.IdMosaNavigation).WithMany(p => p.RelacionAmanteMosas)
                .HasForeignKey(d => d.IdMosa)
                .HasConstraintName("FK__Relacion___IdMos__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
