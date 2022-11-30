using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbBrand
    {
        public TbBrand()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
