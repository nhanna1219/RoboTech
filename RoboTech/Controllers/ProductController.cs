using Microsoft.AspNetCore.Mvc;
using RoboTech.Models;
using RoboTech.Data;

namespace RoboTech.Controllers
{
    public class ProductController : Controller
    {
        private readonly RobotechContext _context;
        public ProductController(RobotechContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Khong render len view nen comment
        //public IActionResult Details(int id)
        //{
        //    var product = _context.TbProducts.Include(x => x.Cate).FirstOrDefault(x => x.ProductId == id);
        //    if (product == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        public IActionResult Details()
        {
            return View();
        }

    }
}
