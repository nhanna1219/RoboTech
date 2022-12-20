using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbOrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? OrderNumber { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual TbOrder Order { get; set; } = null!;
        public virtual TbProduct Product { get; set; } = null!;
    }
}
