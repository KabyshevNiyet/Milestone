using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoService.Data;
using AutoService.Models;

namespace AutoService.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MyContext _context;

        public OrdersController(MyContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Orders.Include(o => o.Autopart).Include(o => o.Client).Include(o => o.Manager);
            return View(await myContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Autopart)
                .Include(o => o.Client)
                .Include(o => o.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["autoparts_id"] = new SelectList(_context.Autoparts, "Id", "Id");
            ViewData["client_id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["manager_id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,autoparts_id,client_id,manager_id,date,total")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["autoparts_id"] = new SelectList(_context.Autoparts, "Id", "Id", orders.autoparts_id);
            ViewData["client_id"] = new SelectList(_context.Users, "Id", "Id", orders.client_id);
            ViewData["manager_id"] = new SelectList(_context.Users, "Id", "Id", orders.manager_id);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["autoparts_id"] = new SelectList(_context.Autoparts, "Id", "Id", orders.autoparts_id);
            ViewData["client_id"] = new SelectList(_context.Users, "Id", "Id", orders.client_id);
            ViewData["manager_id"] = new SelectList(_context.Users, "Id", "Id", orders.manager_id);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,autoparts_id,client_id,manager_id,date,total")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            ViewData["autoparts_id"] = new SelectList(_context.Autoparts, "Id", "Id", orders.autoparts_id);
            ViewData["client_id"] = new SelectList(_context.Users, "Id", "Id", orders.client_id);
            ViewData["manager_id"] = new SelectList(_context.Users, "Id", "Id", orders.manager_id);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Autopart)
                .Include(o => o.Client)
                .Include(o => o.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
