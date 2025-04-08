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

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Advertis__3214EC07972A687F");

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC0744289DAD");

            entity.HasIndex(e => e.CompanyId, "UQ__Companie__2D971C4D5E878B4B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Companie__A9D10534D00E1802").IsUnique();

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

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drivers__3214EC07760719A6");
            entity.HasIndex(e => e.Email, "UQ__Drivers__A9D1053479C68E5D").IsUnique();
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DriverName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC07A9378ED9");

            entity.ToTable("Feedback");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC0700D43165");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentFor).HasMaxLength(50);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payments__UserId__6383C8BA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076DD407FF");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E707C702").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
