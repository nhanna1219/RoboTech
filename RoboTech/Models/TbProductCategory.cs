using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboTech.Models
{
    [Table("tb_ProductCategory")]
    public partial class TbProductCategory
    {
        public TbProductCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        [Key]
        public int CateId { get; set; }
        [StringLength(250)]
        public string Name { get; set; } = null!;
        [Required]
        public bool? Status { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(30)]
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [InverseProperty("Cate")]
        public virtual ICollection<TbProduct> TbProducts { get; set; }
        public string Alias { get; internal set; }
    }
}
