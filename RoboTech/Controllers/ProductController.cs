using Microsoft.AspNetCore.Mvc;
using RoboTech.Models;

namespace RoboTech.Controllers
{
    public class ProductController : Controller
    {
        private readonly shoplaptopContext _context;
        public ProductController(shoplaptopContext context)
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
