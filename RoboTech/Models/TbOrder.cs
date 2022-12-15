using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbOrder
    {
        public TbOrder()
        {
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CustomerId { get; set; }
        public int? TotalMoney { get; set; }

        public virtual TbCustomer? Customer { get; set; }
        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
