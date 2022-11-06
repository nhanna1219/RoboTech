using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbInvoiceDetail
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
