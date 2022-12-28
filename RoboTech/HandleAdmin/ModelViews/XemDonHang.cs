using RoboTech.Models;
using System;
using System.Collections.Generic;

namespace RoboTech.ModelViews
{
    public class XemDonHang
    {
        public TbOrder DonHang { get; set; }
        public List<TbOrderDetail> ChiTietDonHang { get; set; }
    }
}

