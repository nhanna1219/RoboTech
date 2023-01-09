using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using RoboTech.Models;


namespace RoboTech.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoplaptopContext _context;
        public ProductController(ShoplaptopContext context)
        {
            _context = context;
        }
        [Route("ProductList", Name = ("ShopProduct"))]
        public IActionResult Index(int? page)
        {
            
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsTinDangs = _context.TbProducts
                    .AsNoTracking()
                    .OrderBy(x => x.CreatedDate);
                PagedList<TbProduct> models = new PagedList<TbProduct>(lsTinDangs, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "Alias", "Name");
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("danhmuc/{Alias}", Name = ("ListProduct"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = _context.TbProductCategories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsTinDangs = _context.TbProducts
                    .AsNoTracking()
                    .Where(x => x.CateId == danhmuc.CateId)
                    .OrderByDescending(x => x.CreatedDate);
                PagedList<TbProduct> models = new PagedList<TbProduct>(lsTinDangs, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "Alias", "Name");
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{Alias}-{id}", Name = ("ProductDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.TbProducts.Include(x => x.Cate).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories,"Alias", "Name");
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Filtter(string Alias = null)
        {
            var url = $"/danhmuc/{Alias}";
            if (Alias == null)
            {
                url = $"/ProductList";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
    }
}
