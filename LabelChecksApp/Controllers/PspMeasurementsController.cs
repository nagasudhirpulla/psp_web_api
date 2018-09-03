using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelChecksDataLayer.Models;
using PSPDataFetchLayer.Models;

namespace LabelChecksApp.Controllers
{
    public class PspMeasurementsController : Controller
    {
        private readonly LabelChecksDbContext _context;

        public PspMeasurementsController(LabelChecksDbContext context)
        {
            _context = context;
        }

        // GET: PspMeasurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.PspDbMeasurements.ToListAsync());
        }

        // GET: PspMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pspMeasurement = await _context.PspDbMeasurements
                .FirstOrDefaultAsync(m => m.MeasId == id);
            if (pspMeasurement == null)
            {
                return NotFound();
            }

            return View(pspMeasurement);
        }

        // GET: PspMeasurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PspMeasurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeasId,Label,PspTable,PspValCol,PspTimeCol,EntityCol,EntityVal,SqlStr,QueryParams,QueryParamVals")] PspMeasurement pspMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pspMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pspMeasurement);
        }

        // GET: PspMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pspMeasurement = await _context.PspDbMeasurements.FindAsync(id);
            if (pspMeasurement == null)
            {
                return NotFound();
            }
            return View(pspMeasurement);
        }

        // POST: PspMeasurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeasId,Label,PspTable,PspValCol,PspTimeCol,EntityCol,EntityVal,SqlStr,QueryParams,QueryParamVals")] PspMeasurement pspMeasurement)
        {
            if (id != pspMeasurement.MeasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pspMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PspMeasurementExists(pspMeasurement.MeasId))
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
            return View(pspMeasurement);
        }

        // GET: PspMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pspMeasurement = await _context.PspDbMeasurements
                .FirstOrDefaultAsync(m => m.MeasId == id);
            if (pspMeasurement == null)
            {
                return NotFound();
            }

            return View(pspMeasurement);
        }

        // POST: PspMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pspMeasurement = await _context.PspDbMeasurements.FindAsync(id);
            _context.PspDbMeasurements.Remove(pspMeasurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PspMeasurementExists(int id)
        {
            return _context.PspDbMeasurements.Any(e => e.MeasId == id);
        }
    }
}
