using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_OrderDetail")]
    public partial class TbOrderDetail
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string? ProductName { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("TbOrderDetails")]
        public virtual TbOrder Order { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("TbOrderDetails")]
        public virtual TbProduct Product { get; set; } = null!;
    }
}
