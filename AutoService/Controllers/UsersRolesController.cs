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
    public class UsersRolesController : Controller
    {
        private readonly MyContext _context;

        public UsersRolesController(MyContext context)
        {
            _context = context;
        }

        // GET: UsersRoles
        public async Task<IActionResult> Index()
        {
            var myContext = _context.UsersRoles.Include(u => u.Roles).Include(u => u.Users);
            return View(await myContext.ToListAsync());
        }

        // GET: UsersRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRoles = await _context.UsersRoles
                .Include(u => u.Roles)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersRoles == null)
            {
                return NotFound();
            }

            return View(usersRoles);
        }

        // GET: UsersRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UsersRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UsersRoles usersRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usersRoles.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersRoles.UserId);
            return View(usersRoles);
        }

        // GET: UsersRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRoles = await _context.UsersRoles.FindAsync(id);
            if (usersRoles == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usersRoles.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersRoles.UserId);
            return View(usersRoles);
        }

        // POST: UsersRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,RoleId")] UsersRoles usersRoles)
        {
            if (id != usersRoles.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersRolesExists(usersRoles.UserId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usersRoles.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersRoles.UserId);
            return View(usersRoles);
        }

        // GET: UsersRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRoles = await _context.UsersRoles
                .Include(u => u.Roles)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersRoles == null)
            {
                return NotFound();
            }

            return View(usersRoles);
        }

        // POST: UsersRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersRoles = await _context.UsersRoles.FindAsync(id);
            _context.UsersRoles.Remove(usersRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersRolesExists(int id)
        {
            return _context.UsersRoles.Any(e => e.UserId == id);
        }
    }
}
