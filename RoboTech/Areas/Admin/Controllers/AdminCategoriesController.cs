using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using RoboTech.Helper;
using RoboTech.Models;

namespace RoboTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    /*[Authorize(Roles = "Admin")]*/
    public class AdminCategoriesController : Controller
    {
        private readonly ShoplaptopContext _context;
        public INotyfService _notyfService { get; }
        public AdminCategoriesController(ShoplaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminCategories
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsCategorys = _context.TbProductCategories
                .AsNoTracking()
                .OrderBy(x => x.CateId);
            PagedList<TbProductCategory> models = new PagedList<TbProductCategory>(lsCategorys, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProductCategories == null)
            {
                return NotFound();
            }

            var tbProductCategory = await _context.TbProductCategories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (tbProductCategory == null)
            {
                return NotFound();
            }

            return View(tbProductCategory);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CateId,Name,Status,ParentId,CreatedBy,CreatedDate,Alias,Ordering,Published,Thumb,Title,Desciption,UpdatedBy,UpdatedDate")] TbProductCategory tbProductCategory, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                //Xu ly Thumb
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageName = Utilities.SEOUrl(tbProductCategory.Name) + extension;
                    tbProductCategory.Thumb = await Utilities.UploadFile(fThumb, @"category", imageName.ToLower());
                }
                if (string.IsNullOrEmpty(tbProductCategory.Thumb)) tbProductCategory.Thumb = "default.jpg";
                tbProductCategory.Alias = Utilities.SEOUrl(tbProductCategory.Name);
                _context.Add(tbProductCategory);
                await _context.SaveChangesAsync();
                _notyfService.Success("Successfully added new");
                return RedirectToAction(nameof(Index));
            }
            return View(tbProductCategory);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbProductCategories == null)
            {
                return NotFound();
            }

            var tbProductCategory = await _context.TbProductCategories.FindAsync(id);
            if (tbProductCategory == null)
            {
                return NotFound();
            }
            return View(tbProductCategory);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CateId,Name,Status,ParentId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Alias,Ordering,Published,Desciption")] TbProductCategory tbProductCategory, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != tbProductCategory.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string imageName = Utilities.SEOUrl(tbProductCategory.Name) + extension;
                        tbProductCategory.Thumb = await Utilities.UploadFile(fThumb, @"category", imageName.ToLower());
                    }
                    if (string.IsNullOrEmpty(tbProductCategory.Thumb)) tbProductCategory.Thumb = "default.jpg";
                    _context.Update(tbProductCategory);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Chỉnh sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProductCategoryExists(tbProductCategory.CateId))
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
            return View(tbProductCategory);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbProductCategories == null)
            {
                return NotFound();
            }

            var tbProductCategory = await _context.TbProductCategories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (tbProductCategory == null)
            {
                return NotFound();
            }

            return View(tbProductCategory);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.TbProductCategories.FindAsync(id);
            _context.TbProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            _notyfService.Success("Delete successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool TbProductCategoryExists(int id)
        {
          return _context.TbProductCategories.Any(e => e.CateId == id);
        }
    }
}
