using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public bool? Status { get; set; }

    public string? Image { get; set; }

    public string? ListImages { get; set; }

    public int? Price { get; set; }

    public decimal? PromotionPrice { get; set; }

    public int? Quantity { get; set; }

    public int Warranty { get; set; }

    public DateTime? Hot { get; set; }

    public string Description { get; set; } = null!;

    public int? ViewCount { get; set; }

    public int? CateId { get; set; }

    public int? BrandId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Thumb { get; set; }

    public string? Alias { get; set; }

    public int? Discount { get; set; }

    public virtual TbBrand? Brand { get; set; }

    public virtual TbProductCategory? Cate { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; } = new List<TbOrderDetail>();
}
