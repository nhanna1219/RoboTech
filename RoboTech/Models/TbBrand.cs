using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbBrand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; } = new List<TbProduct>();
}
