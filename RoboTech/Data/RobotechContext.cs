using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoboTech.Models;

namespace RoboTech.Data
{
    public partial class RobotechContext : DbContext
    {
        public RobotechContext()
        {
        }

        public RobotechContext(DbContextOptions<RobotechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmins { get; set; } = null!;
        public virtual DbSet<TbBrand> TbBrands { get; set; } = null!;
        public virtual DbSet<TbCustomer> TbCustomers { get; set; } = null!;
        public virtual DbSet<TbFeedback> TbFeedbacks { get; set; } = null!;
        public virtual DbSet<TbOrder> TbOrders { get; set; } = null!;
        public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; } = null!;
        public virtual DbSet<TbProduct> TbProducts { get; set; } = null!;
        public virtual DbSet<TbProductCategory> TbProductCategories { get; set; } = null!;
        public virtual DbSet<TbRole> TbRoles { get; set; } = null!;
        public virtual DbSet<TbSlide> TbSlides { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NHANNA\\SQLEXPRESS;Database=Robotech;Integrated Security=true;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.Property(e => e.Name).HasDefaultValueSql("('Admin')");

                entity.Property(e => e.Password).IsFixedLength();

                entity.Property(e => e.Username).IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbAdmins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Admin_tb_Roles");
            });

            modelBuilder.Entity<TbBrand>(entity =>
            {
                entity.Property(e => e.ProductType).IsFixedLength();
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsFixedLength();

                entity.Property(e => e.Salt).IsFixedLength();
            });

            modelBuilder.Entity<TbOrder>(entity =>
            {
                entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_tb_Orders_tb_Customers");
            });

            modelBuilder.Entity<TbOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TbOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_OrderDetail_tb_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TbOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_OrderDetail_tb_Product");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((10))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_tb_Product_tb_Brand");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_tb_Product_tb_ProductCategory");
            });

            modelBuilder.Entity<TbProductCategory>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Salt).IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tb_User_tb_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
