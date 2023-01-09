using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbCustomer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; } = new List<TbOrder>();
}
