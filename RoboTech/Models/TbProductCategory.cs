using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbProductCategory
{
    public int CateId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public int? ParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Alias { get; set; }

    public int? Ordering { get; set; }

    public bool Published { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; } = new List<TbProduct>();
}
