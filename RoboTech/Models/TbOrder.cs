using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbOrder
{
    public int Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? Status { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? CustomerId { get; set; }

    public int? TotalMoney { get; set; }

    public int? TransactStatusId { get; set; }

    public bool? Deleted { get; set; }

    public string? Note { get; set; }

    public string? Address { get; set; }

    public bool? Paid { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? PaymentId { get; set; }

    public DateTime? ShipDate { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; } = new List<TbOrderDetail>();

    public virtual TransactStatus? TransactStatus { get; set; }
}
