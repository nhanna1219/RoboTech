﻿using System;
using System.Collections.Generic;

namespace RoboTech.Models.Entities
{
    public partial class TbAdmin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}