﻿using System;
using System.Collections.Generic;

namespace RoboTech.Models.Entities
{
    public partial class TbPostTag
    {
        public int PostId { get; set; }
        public string TagId { get; set; } = null!;
    }
}
