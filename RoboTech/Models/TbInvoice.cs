using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbInvoice
    {
        public int InvoiceId { get; set; }
        public bool? Status { get; set; }
        public string? SupplierId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
