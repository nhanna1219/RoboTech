using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Customers")]
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbOrders = new HashSet<TbOrder>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DayOfBirth { get; set; }
        [StringLength(50)]
        public string? Avatar { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        public bool? Active { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<TbOrder> TbOrders { get; set; }
    }
}
