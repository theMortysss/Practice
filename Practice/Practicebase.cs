using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Practice.Entitys;

namespace Practice;

public partial class Practicebase : DbContext
{
    public Practicebase()
    {
    }

    public Practicebase(DbContextOptions<Practicebase> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplie> Supplies { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PharmacyBase.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC073A875030");

            entity.ToTable("Product");

            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("Expiration_date");
            entity.Property(e => e.PackingG).HasColumnName("Packing_g");
            entity.Property(e => e.Price).HasColumnType("smallmoney");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC0739298CE3");

            entity.ToTable("Sale");

            entity.Property(e => e.DateOfSale).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Sale_ToTable");
        });

        modelBuilder.Entity<Supplie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplie__3214EC0790A9B44D");

            entity.ToTable("Supplie");

            entity.Property(e => e.DateOfSupplie).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Table_ToTable_1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Table_ToTable");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC076370AFA8");

            entity.ToTable("Supplier");

            entity.Property(e => e.DistanceKm).HasColumnName("Distance_km");
            entity.Property(e => e.Price).HasColumnType("smallmoney");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.ShippingCoast)
                .HasColumnType("smallmoney")
                .HasColumnName("Shipping_Coast");

            entity.HasOne(d => d.Product).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Supplier_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
