﻿    using System;
using System.Collections.Generic;
#nullable disable
namespace RoboTech.Models
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbOrders = new HashSet<TbOrder>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TbOrder> TbOrders { get; set; }
    }
}
