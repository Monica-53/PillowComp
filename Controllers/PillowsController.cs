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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pillow.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Name,ManufactureDate,Colour,Size,Price")] Pillow pillow)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ManufactureDate,Colour,Size,Price")] Pillow pillow)
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
