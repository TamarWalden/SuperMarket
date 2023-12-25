using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository_Dal.Models;

public partial class SuperMarketContext : DbContext,IContext
{
    public SuperMarketContext()
    {
    }

    public SuperMarketContext(DbContextOptions<SuperMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Shopping> Shoppings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SuperMarket;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__companie__357D4CF87C34D797");

            entity.ToTable("companies");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__customer__357D4CF8711B4E88");

            entity.ToTable("customers");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__departme__357D4CF85A452379");

            entity.ToTable("departments");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__products__357D4CF8E5395555");

            entity.ToTable("products");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.CompanyCode).HasColumnName("company_code");
            entity.Property(e => e.DepartmentCode).HasColumnName("department_code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.CompanyCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyCode)
                .HasConstraintName("FK__products__compan__3C69FB99");

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.DepartmentCode)
                .HasConstraintName("FK__products__depart__3B75D760");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__purchase__357D4CF8798D2683");

            entity.ToTable("purchase_details");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.ProductCode).HasColumnName("product_code");
            entity.Property(e => e.PurchaseCode).HasColumnName("purchase_code");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ProductCode)
                .HasConstraintName("FK__purchase___produ__44FF419A");

            entity.HasOne(d => d.PurchaseCodeNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseCode)
                .HasConstraintName("FK__purchase___purch__440B1D61");
        });

        modelBuilder.Entity<Shopping>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__shopping__357D4CF89AE83A2A");

            entity.ToTable("shopping");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.CustomerCode).HasColumnName("customer_code");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("delivery_address");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Shoppings)
                .HasForeignKey(d => d.CustomerCode)
                .HasConstraintName("FK__shopping__custom__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
