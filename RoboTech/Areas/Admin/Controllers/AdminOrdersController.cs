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
    public class AdminOrdersController : Controller
    {
        private readonly ShoplaptopContext _context;
        public INotyfService _notyfService { get; }
        public AdminOrdersController(ShoplaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminOrders

        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var Orders = _context.TbOrders.Include(o => o.Customer)
                .Include(o => o.TransactStatus)
                .AsNoTracking()
                .OrderBy(x => x.OrderDate);
            PagedList<TbOrder> models = new PagedList<TbOrder>(Orders, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;



            return View(models);
        }

        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.TbOrders
                .Include(o => o.Customer)
                .Include(o => o.TransactStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var Chitietdonhang = _context.TbOrderDetails
                .Include(x => x.Product)
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .OrderBy(x => x.OrderDetailId)
                .ToList();
            ViewBag.ChiTiet = Chitietdonhang;
            return View(order);
        }


        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.TbOrders
                .AsNoTracking()
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Trangthai"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "Status", order.TransactStatusId);
            return PartialView("ChangeStatus", order);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, [Bind("Id,CustomerId,OrderDate,Deleted,ShipDate,TransactStatusId,Paid,PaymentDate,TotalMoney,PaymentId,Note,Address")] TbOrder order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var donhang = await _context.TbOrders.AsNoTracking().Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
                    if (donhang != null)
                    {
                        donhang.Paid = order.Paid;
                        donhang.Deleted = order.Deleted;
                        donhang.TransactStatusId = order.TransactStatusId;
                        if (donhang.Paid == true)
                        {
                            donhang.PaymentDate = DateTime.Now;
                        }
                        if (donhang.TransactStatusId == 5) donhang.Deleted = true;
                        if (donhang.TransactStatusId == 3) donhang.ShipDate = DateTime.Now;
                    }
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Order status update successful!");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["Trangthai"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "Status", order.TransactStatusId);
            return PartialView("ChangeStatus", order);
        }

        // GET: Admin/AdminOrders/Create
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = await _context.TbOrders
                .Include(o => o.Customer)
                .Include(o => o.TransactStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var Chitietdonhang = _context.TbOrderDetails
                .Include(x => x.Product)
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .OrderBy(x => x.OrderDetailId)
                .ToList();
            ViewBag.ChiTiet = Chitietdonhang;

            return View(order);
      
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.TbOrders.FindAsync(id);
            order.Deleted = true;
            _context.Update(order);
            await _context.SaveChangesAsync();
            _notyfService.Success("Deleted order successfully!");
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.TbOrders.Any(e => e.Id == id);
        }

    }
}
