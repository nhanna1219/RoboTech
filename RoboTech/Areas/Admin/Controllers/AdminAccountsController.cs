using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoboTech.Models;

namespace RoboTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly shoplaptopContext _context;

        public AdminAccountsController(shoplaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.TbRoles, "RoleId", "Description");
            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem() { Text = "Hoạt động", Value = "1" });
            lsTrangThai.Add(new SelectListItem() { Text = "Khóa", Value = "0" });
            ViewData["lsTrangThai"] = lsTrangThai;
            
            var shoplaptopContext = _context.TbUsers.Include(t => t.Role);
            return View(await shoplaptopContext.ToListAsync());
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbUsers == null)
            {
                return NotFound();
            }

            var tbUser = await _context.TbUsers
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUser == null)
            {
                return NotFound();
            }

            return View(tbUser);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId");
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Password,Address,RoleId,LastLogin,CreateDate,Active,Phone,Email,Salt")] TbUser tbUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId", tbUser.RoleId);
            return View(tbUser);
        }

        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbUsers == null)
            {
                return NotFound();
            }

            var tbUser = await _context.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId", tbUser.RoleId);
            return View(tbUser);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Password,Address,RoleId,LastLogin,CreateDate,Active,Phone,Email,Salt")] TbUser tbUser)
        {
            if (id != tbUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbUserExists(tbUser.Id))
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
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId", tbUser.RoleId);
            return View(tbUser);
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbUsers == null)
            {
                return NotFound();
            }

            var tbUser = await _context.TbUsers
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUser == null)
            {
                return NotFound();
            }

            return View(tbUser);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbUsers == null)
            {
                return Problem("Entity set 'shoplaptopContext.TbUsers'  is null.");
            }
            var tbUser = await _context.TbUsers.FindAsync(id);
            if (tbUser != null)
            {
                _context.TbUsers.Remove(tbUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbUserExists(int id)
        {
          return _context.TbUsers.Any(e => e.Id == id);
        }
    }
}
