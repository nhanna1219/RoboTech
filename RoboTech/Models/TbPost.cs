using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbPost
    {
        public int PostId { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public int? ViewCount { get; set; }
        public int? CateId { get; set; }
        public string? Tags { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
