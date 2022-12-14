using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoboTech.Models
{
    [Table("tb_Brand")]
    public partial class TbBrand
    {
        public TbBrand()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(250)]
        public string? Name { get; set; }
        [StringLength(20)]
        public string? ProductType { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
