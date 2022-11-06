using System;
using System.Collections.Generic;

namespace RoboTech.Models.Entities
{
    public partial class TbUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Active { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Salt { get; set; }

        public virtual TbRole? Role { get; set; }
    }
}
