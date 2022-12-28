using System;
using System.ComponentModel.DataAnnotations;

namespace RoboTech.ModelViews
{
    public class MuaHangVM
    {

        public int CustomerId { get; set; }
       
        public string FullName { get; set; }
        public string Email { get; set; }
        
        public string Phone { get; set; }
        public string Address { get; set; }
/*        public int PaymentID { get; set; }*/
        public string? Note { get; set; }
    }
}
