using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoboTech.Models
{
    public partial class shoplaptopContext : DbContext
    {
        public shoplaptopContext()
        {
        }

        public shoplaptopContext(DbContextOptions<shoplaptopContext> options)
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
                optionsBuilder.UseSqlServer("Server=ELONMUSK;Database=shoplaptop;Trusted_Connection=True;");
            }
        }

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
                    .HasColumnName("NAME")
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbAdmins)
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

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

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

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_tb_Orders_tb_Customers");
            });

            modelBuilder.Entity<TbOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("tb_OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).HasMaxLength(50);

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

            /*modelBuilder.Entity<TbPost>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tb_Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.MetaDescription).HasMaxLength(250);

                entity.Property(e => e.MetaKeyword).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPostComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("tb_PostComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Detail).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });*/

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tb_Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Hot).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.ListImages).HasColumnType("xml");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

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
                entity.HasKey(e => e.CateId);

                entity.ToTable("tb_ProductCategory");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

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
