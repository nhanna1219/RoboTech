using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Orders")]
    public partial class TbOrder
    {
        public TbOrder()
        {
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("TbOrders")]
        public virtual TbCustomer? Customer { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
