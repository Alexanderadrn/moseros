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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
