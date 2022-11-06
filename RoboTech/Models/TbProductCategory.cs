﻿using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbProductCategory
    {
        public int CateId { get; set; }
        public string Name { get; set; } = null!;
        public string? SeoTitle { get; set; }
        public bool? Status { get; set; }
        public int? Sort { get; set; }
        public int? ParentId { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}