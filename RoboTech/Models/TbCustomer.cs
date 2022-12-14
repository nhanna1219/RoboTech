#nullable disable

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
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Avatar { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        public int? Zip { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
        public bool? Active { get; set; }
        [Column("salt")]
        [StringLength(10)]
        public string? Salt { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<TbOrder> TbOrders { get; set; }
    }
}
