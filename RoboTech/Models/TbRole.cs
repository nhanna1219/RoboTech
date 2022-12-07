using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Roles")]
    public partial class TbRole
    {
        public TbRole()
        {
            TbAdmins = new HashSet<TbAdmin>();
            TbUsers = new HashSet<TbUser>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(50)]
        public string? RoleName { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<TbAdmin> TbAdmins { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<TbUser> TbUsers { get; set; }
    }
}
