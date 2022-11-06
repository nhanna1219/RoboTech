using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbOrder
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Status { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CustomerId { get; set; }
        public int? Discount { get; set; }
    }
}
