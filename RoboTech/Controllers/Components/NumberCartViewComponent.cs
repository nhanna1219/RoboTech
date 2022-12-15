using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboTech.HandleAdmin.Extension;
using RoboTech.ModelViews;

namespace RoboTech.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
