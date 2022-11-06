using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbConfig
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool? Status { get; set; }
    }
}
