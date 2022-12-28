using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoboTech.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Feedback", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_ProductCategory",
                columns: table => new
                {
                    CateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Alias = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProductCategory", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Slide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Slide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    TotalMoney = table.Column<int>(type: "int", nullable: true),
                    TransactStatusId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Orders_tb_Customers",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "tb_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ListImages = table.Column<string>(type: "xml", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    Hot = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: true),
                    CateID = table.Column<int>(type: "int", nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Thumb = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Alias = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_tb_Product_tb_Brand",
                        column: x => x.BrandID,
                        principalTable: "tb_Brand",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_Product_tb_ProductCategory",
                        column: x => x.CateID,
                        principalTable: "tb_ProductCategory",
                        principalColumn: "CateId");
                });

            migrationBuilder.CreateTable(
                name: "tb_Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, defaultValueSql: "('Admin')"),
                    username = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Admin_tb_Roles",
                        column: x => x.RoleID,
                        principalTable: "tb_Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salt = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_User_tb_Roles",
                        column: x => x.RoleID,
                        principalTable: "tb_Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "tb_OrderDetail",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    TotalMoney = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_OrderDetail", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Orders",
                        column: x => x.OrderID,
                        principalTable: "tb_Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Product",
                        column: x => x.ProductID,
                        principalTable: "tb_Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Admin_RoleID",
                table: "tb_Admin",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_ProductID",
                table: "tb_OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Orders_CustomerID",
                table: "tb_Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Product_BrandID",
                table: "tb_Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Product_CateID",
                table: "tb_Product",
                column: "CateID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_User_RoleID",
                table: "tb_User",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Admin");

            migrationBuilder.DropTable(
                name: "tb_Feedback");

            migrationBuilder.DropTable(
                name: "tb_OrderDetail");

            migrationBuilder.DropTable(
                name: "tb_Slide");

            migrationBuilder.DropTable(
                name: "tb_User");

            migrationBuilder.DropTable(
                name: "tb_Orders");

            migrationBuilder.DropTable(
                name: "tb_Product");

            migrationBuilder.DropTable(
                name: "tb_Roles");

            migrationBuilder.DropTable(
                name: "tb_Customers");

            migrationBuilder.DropTable(
                name: "tb_Brand");

            migrationBuilder.DropTable(
                name: "tb_ProductCategory");
        }
    }
}
