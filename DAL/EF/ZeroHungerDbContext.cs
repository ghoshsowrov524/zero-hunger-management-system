using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class ZeroHungerDbContext : DbContext
{
    public ZeroHungerDbContext()
    {
    }

    public ZeroHungerDbContext(DbContextOptions<ZeroHungerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectRequest> CollectRequests { get; set; }

    public virtual DbSet<Distribution> Distributions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectRequest>(entity =>
        {
            entity.Property(e => e.CollectedDate).HasColumnType("datetime");
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.MaximumPreserveTime).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending", "DF_CollectRequests_Status");

            entity.HasOne(d => d.Employee).WithMany(p => p.CollectRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectRequests_Employees");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.CollectRequests)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectRequests_Restaurants");
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            entity.Property(e => e.DistributionDate).HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.CollectRequest).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.CollectRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distributions_CollectRequests");

            entity.HasOne(d => d.Employee).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distributions_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Employees_IsActive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FoodName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qty).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CollectRequest).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.CollectRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodItems_CollectRequests");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
