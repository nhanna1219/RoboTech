using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbProductCategory
    {
        public TbProductCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int CateId { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Alias { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
