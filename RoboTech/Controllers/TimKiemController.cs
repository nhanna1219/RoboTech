using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboTech.Models;

namespace RoboTech.Controllers
{
    public class TimKiemController : Controller
    {
        private readonly ShoplaptopContext _context;
        public INotyfService _notyfService { get; }
        public TimKiemController(ShoplaptopContext context)
        {
            _context = context;
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult FindProduct(string keyword)
        {
            List<TbProduct> ls = new List<TbProduct>();
            /*if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return View();
            }*/
            ls = _context.TbProducts.
                                  Where(x => x.Name.Contains(keyword))
                                  .OrderByDescending(x => x.Name)
                                  .Take(10)
                                  .ToList();
            ViewBag.Keyword = keyword;
            return View(ls);
        }
    }
}
