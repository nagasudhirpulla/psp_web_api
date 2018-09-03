using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelChecksDataLayer.Models;

namespace LabelChecksApp.Controllers
{
    public class LabelChecksController : Controller
    {
        private readonly LabelChecksDbContext _context;

        public LabelChecksController(LabelChecksDbContext context)
        {
            _context = context;
        }

        // GET: LabelChecks
        public async Task<IActionResult> Index()
        {
            var labelChecksDbContext = _context.LabelChecks.Include(l => l.PspMeasurement);
            return View(await labelChecksDbContext.ToListAsync());
        }

        // GET: LabelChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheck = await _context.LabelChecks
                .Include(l => l.PspMeasurement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelCheck == null)
            {
                return NotFound();
            }

            return View(labelCheck);
        }

        // GET: LabelChecks/Create
        public IActionResult Create()
        {
            ViewData["PspMeasurementId"] = new SelectList(_context.PspDbMeasurements, "MeasId", "Label");
            return View();
        }

        // POST: LabelChecks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckType,Num1,Num2,ConsiderStartTime,ConsiderEndTime,PspMeasurementId")] LabelCheck labelCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labelCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PspMeasurementId"] = new SelectList(_context.PspDbMeasurements, "MeasId", "Label", labelCheck.PspMeasurementId);
            return View(labelCheck);
        }

        // GET: LabelChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheck = await _context.LabelChecks.FindAsync(id);
            if (labelCheck == null)
            {
                return NotFound();
            }
            ViewData["PspMeasurementId"] = new SelectList(_context.PspDbMeasurements, "MeasId", "Label", labelCheck.PspMeasurementId);
            return View(labelCheck);
        }

        // POST: LabelChecks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckType,Num1,Num2,ConsiderStartTime,ConsiderEndTime,PspMeasurementId")] LabelCheck labelCheck)
        {
            if (id != labelCheck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labelCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelCheckExists(labelCheck.Id))
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
            ViewData["PspMeasurementId"] = new SelectList(_context.PspDbMeasurements, "MeasId", "Label", labelCheck.PspMeasurementId);
            return View(labelCheck);
        }

        // GET: LabelChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheck = await _context.LabelChecks
                .Include(l => l.PspMeasurement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelCheck == null)
            {
                return NotFound();
            }

            return View(labelCheck);
        }

        // POST: LabelChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labelCheck = await _context.LabelChecks.FindAsync(id);
            _context.LabelChecks.Remove(labelCheck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelCheckExists(int id)
        {
            return _context.LabelChecks.Any(e => e.Id == id);
        }
    }
}
