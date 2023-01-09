using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using RoboTech.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoboTech.Helper;

namespace RoboTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly ShoplaptopContext _context;
        public INotyfService _notyfService { get; }
        public AdminProductsController(ShoplaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminProducts
        public async Task<IActionResult> Index(int page = 1, int CatID = 0)
        {
            var pageNumber = page;
            var pageSize = 20;
            List<TbProduct> lsProducts = new List<TbProduct>();
            if (CatID != 0)
            {
                lsProducts = _context.TbProducts
                .AsNoTracking()
                .Where(x => x.CateId == CatID)
                .Include(x => x.Cate)
                .OrderBy(x => x.ProductId).ToList();
            }
            else
            {
                lsProducts = _context.TbProducts
                .AsNoTracking()
                .Include(x => x.Cate)
                .OrderBy(x => x.ProductId).ToList();
            }



            PagedList<TbProduct> models = new PagedList<TbProduct>(lsProducts.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = CatID;

            ViewBag.CurrentPage = pageNumber;

            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CateId", "Name");

            return View(models);
            var RobotechContext = _context.TbProducts.Include(t => t.Cate);
            return View(await RobotechContext.ToListAsync());
        }

        // GET: Admin/AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.Cate)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CateId", "Name");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Description,Detail,ViewCount,CateId,BrandId,SupplierId,MetaKeyword,MetaDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] TbProduct tbProduct, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                tbProduct.Name = Utilities.ToTitleCase(tbProduct.Name);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(tbProduct.Name) + extension;
                    tbProduct.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                }
                if (string.IsNullOrEmpty(tbProduct.Thumb)) tbProduct.Thumb = "default.jpg";
                tbProduct.Alias = Utilities.SEOUrl(tbProduct.Name);
               /* tbProduct.DateModified = DateTime.Now;
                tbProduct.DateCreated = DateTime.Now;*/

                _context.Add(tbProduct);
                await _context.SaveChangesAsync();
                _notyfService.Success("Successfully added new");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CateId", "Name", tbProduct.CateId);
            /*ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CatId", "Name");*/
            return View(tbProduct);
        }

        // GET: Admin/AdminProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CateId", "Name", tbProduct.CateId);
            return View(tbProduct);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Description,Detail,ViewCount,CateId,BrandId,SupplierId,MetaKeyword,MetaDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] TbProduct tbProduct, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != tbProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tbProduct.Name = Utilities.ToTitleCase(tbProduct.Name);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(tbProduct.Name) + extension;
                        tbProduct.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(tbProduct.Thumb)) tbProduct.Thumb = "default.jpg";
                    tbProduct.Alias = Utilities.SEOUrl(tbProduct.Name);
                    /*tbProduct.DateModified = DateTime.Now;*/

                    _context.Update(tbProduct);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProductExists(tbProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CateId", "Name", tbProduct.CateId);
            return View(tbProduct);
        }
        public IActionResult Filtter(int CatID = 0)
        {
            var url = $"/Admin/AdminProducts?CatID={CatID}";
            if (CatID == 0)
            {
                url = $"/Admin/AdminProducts";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.Cate)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbProducts == null)
            {
                return Problem("Entity set 'ShoplaptopContext.TbProducts'  is null.");
            }
            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct != null)
            {
                _context.TbProducts.Remove(tbProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProductExists(int id)
        {
            return _context.TbProducts.Any(e => e.ProductId == id);
        }
    }
}
