using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoService.Data;
using AutoService.Models;
using AutoService.Services;

namespace AutoService.Controllers
{
    public class AutopartsController : Controller
    {
        private readonly AutopartsServices _autopartsServices;

        public AutopartsController(AutopartsServices autopartsServices)
        {
            _autopartsServices = autopartsServices;
        }

        // GET: Autoparts
        public async Task<IActionResult> Index()
        {
            var autoparts = await _autopartsServices.GetAutoparts();
            return View(autoparts);
        }

        // GET: Autoparts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoparts = await _autopartsServices.DetailsAutoparts(id);
            if (autoparts == null)
            {
                return NotFound();
            }

            return View(autoparts);
        }

        // GET: Autoparts/Create
        public IActionResult Create()
        {
            ViewData["car_id"] = new SelectList(_autopartsServices.getCars(), "Id", "Id");
            ViewData["typesautopart_id"] = new SelectList(_autopartsServices.getTypesAutoparts(), "Id", "Id");
            return View();
        }

        // POST: Autoparts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,car_id,typesautopart_id,name,price")] Autoparts autoparts)
        {
            if (ModelState.IsValid)
            {
                await _autopartsServices.AddAndSave(autoparts);
                return RedirectToAction(nameof(Index));
            }
            ViewData["car_id"] = new SelectList(_autopartsServices.getCars(), "Id", "Id", autoparts.car_id);
            ViewData["typesautopart_id"] = new SelectList(_autopartsServices.getTypesAutoparts(), "Id", "Id", autoparts.typesautopart_id);
            return View(autoparts);
        }

        // GET: Autoparts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoparts = await _autopartsServices.DetailsAutoparts(id);
            if (autoparts == null)
            {
                return NotFound();
            }
            ViewData["car_id"] = new SelectList(_autopartsServices.getCars(), "Id", "Id", autoparts.car_id);
            ViewData["typesautopart_id"] = new SelectList(_autopartsServices.getTypesAutoparts(), "Id", "Id", autoparts.typesautopart_id);
            return View(autoparts);
        }

        // POST: Autoparts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,car_id,typesautopart_id,name,price")] Autoparts autoparts)
        {
            if (id != autoparts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _autopartsServices.Update(autoparts);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutopartsExists(autoparts.Id))
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
            ViewData["car_id"] = new SelectList(_autopartsServices.getCars(), "Id", "Id", autoparts.car_id);
            ViewData["typesautopart_id"] = new SelectList(_autopartsServices.getTypesAutoparts(), "Id", "Id", autoparts.typesautopart_id);
            return View(autoparts);
        }

        // GET: Autoparts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoparts = await _autopartsServices.DetailsAutoparts(id);
            if (autoparts == null)
            {
                return NotFound();
            }

            return View(autoparts);
        }

        // POST: Autoparts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoparts = await _autopartsServices.DetailsAutoparts(id);
            await _autopartsServices.Delete(autoparts);
            return RedirectToAction(nameof(Index));
        }

        private bool AutopartsExists(int id)
        {
            return _autopartsServices.AutopartsExis(id);
        }
    }
}
