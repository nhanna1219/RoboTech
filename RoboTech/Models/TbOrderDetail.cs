using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboTech.Models
{
    public partial class TbOrderDetail
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public int? OrderNumber { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual TbOrder Order { get; set; } = null!;
        public virtual TbProduct Product { get; set; } = null!;
    }
}
