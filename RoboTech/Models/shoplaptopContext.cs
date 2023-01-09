using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models;

public partial class ShoplaptopContext : DbContext
{
    public ShoplaptopContext()
    {
    }

    public ShoplaptopContext(DbContextOptions<ShoplaptopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbBrand> TbBrands { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbFeedback> TbFeedbacks { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbSlide> TbSlides { get; set; }

    public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ELONMUSK;Database=shoplaptop;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.ToTable("tb_Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('Admin')")
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.TbAdmins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tb_Admin_tb_Roles");
        });

        modelBuilder.Entity<TbBrand>(entity =>
        {
            entity.ToTable("tb_Brand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("tb_Customers");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbFeedback>(entity =>
        {
            entity.ToTable("tb_Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.ToTable("tb_Orders");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tb_Orders_tb_Customers");

            entity.HasOne(d => d.TransactStatus).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.TransactStatusId)
                .HasConstraintName("FK_tb_Orders_tb_TransactStatus1");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK_tb_OrderDetail_1");

            entity.ToTable("tb_OrderDetail");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_tb_OrderDetail_tb_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tb_OrderDetail_tb_Product");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tb_Product");

            entity.Property(e => e.Alias)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Hot).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.ListImages).HasColumnType("xml");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Price).HasDefaultValueSql("((0))");
            entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.Thumb)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_tb_Product_tb_Brand");

            entity.HasOne(d => d.Cate).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK_tb_Product_tb_ProductCategory");
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("tb_ProductCategory");

            entity.Property(e => e.Alias)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Thumb).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tb_Roles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSlide>(entity =>
        {
            entity.ToTable("tb_Slide");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TransactStatus>(entity =>
        {
            entity.HasKey(e => e.TransactStatusId);

            entity.ToTable("tb_TransactStatus");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.ToTable("tb_User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tb_User_tb_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
