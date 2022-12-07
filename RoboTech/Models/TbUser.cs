using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_User")]
    public partial class TbUser
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }
        [StringLength(50)]
        public string? Username { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [StringLength(10)]
        public string? Address { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? Active { get; set; }
        [StringLength(12)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("TbUsers")]
        public virtual TbRole? Role { get; set; }
    }
}
