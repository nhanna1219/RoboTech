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
        public bool? Active { get; set; }
        [Column("salt")]
        [StringLength(10)]
        public string? Salt { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<TbOrder> TbOrders { get; set; }
    }
}
