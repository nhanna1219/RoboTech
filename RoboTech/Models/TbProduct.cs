using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Product")]
    public partial class TbProduct
    {
        public TbProduct()
        {
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [StringLength(250)]
        public string? Name { get; set; }
        public bool? Status { get; set; }
        [StringLength(250)]
        public string? Image { get; set; }
        [Column(TypeName = "xml")]
        public string? ListImages { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PromotionPercentage { get; set; }
        [Column(TypeName = "money")]
        public decimal? PromotionPrice { get; set; }
        public int? Quantity { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public int? ViewCount { get; set; }
        [Column("CateID")]
        public int? CateId { get; set; }
        [Column("BrandID")]
        public int? BrandId { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("TbProducts")]
        public virtual TbBrand? Brand { get; set; }
        [ForeignKey("CateId")]
        [InverseProperty("TbProducts")]
        public virtual TbProductCategory? Cate { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
