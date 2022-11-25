using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using RoboTech.Models;

namespace RoboTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly shoplaptopContext _context;
        public INotyfService _notyfService { get; }
        public AdminProductsController(shoplaptopContext context, INotyfService notyfService)
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

            ViewData["DanhMuc"] = new SelectList(_context.TbProductCategories, "CatId", "CatName");

            return View(models);
            var shoplaptopContext = _context.TbProducts.Include(t => t.Cate);
            return View(await shoplaptopContext.ToListAsync());
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
            ViewData["CateId"] = new SelectList(_context.TbPostCategories, "CateId", "CateId");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Description,Detail,ViewCount,CateId,BrandId,SupplierId,MetaKeyword,MetaDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] TbProduct tbProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.TbPostCategories, "CateId", "CateId", tbProduct.CateId);
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
            ViewData["CateId"] = new SelectList(_context.TbPostCategories, "CateId", "CateId", tbProduct.CateId);
            return View(tbProduct);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Description,Detail,ViewCount,CateId,BrandId,SupplierId,MetaKeyword,MetaDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] TbProduct tbProduct)
        {
            if (id != tbProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProduct);
                    await _context.SaveChangesAsync();
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
            ViewData["CateId"] = new SelectList(_context.TbPostCategories, "CateId", "CateId", tbProduct.CateId);
            return View(tbProduct);
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
                return Problem("Entity set 'shoplaptopContext.TbProducts'  is null.");
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
