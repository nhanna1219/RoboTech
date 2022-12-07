﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Admin")]
    public partial class TbAdmin
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(32)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("username")]
        [StringLength(10)]
        public string Username { get; set; } = null!;
        [Column("password")]
        [StringLength(10)]
        public string Password { get; set; } = null!;
        [Column("RoleID")]
        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("TbAdmins")]
        public virtual TbRole? Role { get; set; }
    }
}
