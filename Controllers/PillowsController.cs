using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PillowComp.Data;
using PillowComp.Models;

namespace PillowComp.Controllers
{
    public class PillowsController : Controller
    {
        private readonly PillowCompContext _context;

        public PillowsController(PillowCompContext context)
        {
            _context = context;
        }

        // GET: Pillows
        public async Task<IActionResult> Index(string searchString)
        {
            var pillows = from m in _context.Pillow
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                pillows = pillows.Where(s => s.Name.Contains(searchString));
            }
            //return View(await _context.Pillow.ToListAsync());
            return View(await pillows.ToListAsync());
        }

        // GET: Pillows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pillow == null)
            {
                return NotFound();
            }

            return View(pillow);
        }

        // GET: Pillows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pillows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public async Task<IActionResult> Create([Bind("ID,Name,ManufactureDate,Colour,Size,Price,Rating")] Pillow pillow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pillow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pillow);
        }

        // GET: Pillows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow.FindAsync(id);
            if (pillow == null)
            {
                return NotFound();
            }
            return View(pillow);
        }

        // POST: Pillows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ManufactureDate,Colour,Size,Price,Rating")] Pillow pillow)
        {
            if (id != pillow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pillow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PillowExists(pillow.Id))
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
            return View(pillow);
        }

        // GET: Pillows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pillow == null)
            {
                return NotFound();
            }

            return View(pillow);
        }

        // POST: Pillows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pillow = await _context.Pillow.FindAsync(id);
            _context.Pillow.Remove(pillow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PillowExists(int id)
        {
            return _context.Pillow.Any(e => e.Id == id);
        }
    }
}
