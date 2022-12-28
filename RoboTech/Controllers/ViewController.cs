using Microsoft.AspNetCore.Mvc;

namespace RoboTech.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
