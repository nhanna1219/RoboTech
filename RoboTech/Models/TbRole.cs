using System;
using System.Collections.Generic;

namespace RoboTech.Models
{
    public partial class TbRole
    {
        public TbRole()
        {
            TbAdmins = new HashSet<TbAdmin>();
            TbUsers = new HashSet<TbUser>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TbAdmin> TbAdmins { get; set; }
        public virtual ICollection<TbUser> TbUsers { get; set; }
    }
}
