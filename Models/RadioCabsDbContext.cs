using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RadioCabs.Models;

public partial class RadioCabsDbContext : DbContext
{
    public RadioCabsDbContext()
    {
    }

    public RadioCabsDbContext(DbContextOptions<RadioCabsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC07850F81E5");

            entity.HasIndex(e => e.CompanyId, "UQ__Companie__2D971C4D137733C2").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Companie__A9D10534EB5CED38").IsUnique();

            entity.Property(e => e.CompanyId)
                .HasMaxLength(50)
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.MembershipType).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC076A56C5E5");

            entity.Property(e => e.AvailableCity).HasMaxLength(150);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FarePerKm).HasMaxLength(255);
            entity.Property(e => e.VehicleType).HasMaxLength(120);

            entity.HasOne(d => d.Company).WithMany(p => p.Services)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Services__FarePe__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
