using Microsoft.AspNetCore.Mvc;
using RoboTech.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace RoboTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly ShoplaptopContext _context;

        public SearchController(ShoplaptopContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<TbProduct> ls = new List<TbProduct>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            ls = _context.TbProducts.AsNoTracking()
                                  .Include(a => a.Cate)
                                  .Where(x => x.Name.Contains(keyword))
                                  .OrderByDescending(x => x.Name)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductsSearchPartial", ls);
            }
        } 
    }
}
