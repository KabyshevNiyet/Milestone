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
    public class TypesAutopartController : Controller
    {
        private readonly MyContext _context;

        public TypesAutopartController(MyContext context)
        {
            _context = context;
        }

        // GET: TypesAutopart
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesAutopart.ToListAsync());
        }

        // GET: TypesAutopart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesAutopart = await _context.TypesAutopart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesAutopart == null)
            {
                return NotFound();
            }

            return View(typesAutopart);
        }

        // GET: TypesAutopart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesAutopart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] TypesAutopart typesAutopart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesAutopart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typesAutopart);
        }

        // GET: TypesAutopart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesAutopart = await _context.TypesAutopart.FindAsync(id);
            if (typesAutopart == null)
            {
                return NotFound();
            }
            return View(typesAutopart);
        }

        // POST: TypesAutopart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] TypesAutopart typesAutopart)
        {
            if (id != typesAutopart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesAutopart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesAutopartExists(typesAutopart.Id))
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
            return View(typesAutopart);
        }

        // GET: TypesAutopart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesAutopart = await _context.TypesAutopart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesAutopart == null)
            {
                return NotFound();
            }

            return View(typesAutopart);
        }

        // POST: TypesAutopart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesAutopart = await _context.TypesAutopart.FindAsync(id);
            _context.TypesAutopart.Remove(typesAutopart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesAutopartExists(int id)
        {
            return _context.TypesAutopart.Any(e => e.Id == id);
        }
    }
}
