using System;
using System.Collections.Generic;

namespace RoboTech.Models;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbAdmin> TbAdmins { get; } = new List<TbAdmin>();

    public virtual ICollection<TbUser> TbUsers { get; } = new List<TbUser>();
}
