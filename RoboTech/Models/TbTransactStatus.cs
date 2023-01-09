using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TransactStatus
{
    public int TransactStatusId { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; } = new List<TbOrder>();
}
