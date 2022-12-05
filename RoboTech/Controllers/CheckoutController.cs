using Microsoft.AspNetCore.Mvc;

namespace RoboTech.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
