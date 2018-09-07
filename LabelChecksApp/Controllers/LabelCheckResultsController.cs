using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabelChecksDataLayer.Models;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace LabelChecksApp.Controllers
{
    public class LabelCheckResultsController : Controller
    {
        private readonly LabelChecksDbContext _context;
        private IConfiguration Configuration { get; }
        public LabelCheckResultsController(LabelChecksDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: LabelCheckResults
        public async Task<IActionResult> Index(string dateStr)
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<LabelCheckResult, PSPDataFetchLayer.Models.PspMeasurement> labelChecksDbContext;
            if (!String.IsNullOrEmpty(dateStr))
            {
                labelChecksDbContext = _context.LabelCheckResults.Where(r => r.CheckProcessStartTime.ToString("yyyy-MM-dd") == dateStr).Include(l => l.LabelCheck).Include(l => l.LabelCheck.PspMeasurement);
            }
            else
            {            
            labelChecksDbContext = _context.LabelCheckResults.Include(l => l.LabelCheck).Include(l => l.LabelCheck.PspMeasurement);
            }
            //List<LabelCheckResult> lst = await labelChecksDbContext.ToListAsync();
            return View(await labelChecksDbContext.ToListAsync());
        }

        // GET: LabelCheckResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheckResult = await _context.LabelCheckResults
                .Include(l => l.LabelCheck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelCheckResult == null)
            {
                return NotFound();
            }

            return View(labelCheckResult);
        }

        // GET: LabelCheckResults/Create
        public IActionResult Create()
        {
            ViewData["LabelCheckId"] = new SelectList(_context.LabelChecks, "Id", "CheckType");
            return View();
        }

        // POST: LabelCheckResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsSuccessful,CheckProcessStartTime,CheckProcessEndTime,Remarks,LabelCheckId")] LabelCheckResult labelCheckResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labelCheckResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabelCheckId"] = new SelectList(_context.LabelChecks, "Id", "CheckType", labelCheckResult.LabelCheckId);
            return View(labelCheckResult);
        }

        // GET: LabelCheckResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheckResult = await _context.LabelCheckResults.FindAsync(id);
            if (labelCheckResult == null)
            {
                return NotFound();
            }
            ViewData["LabelCheckId"] = new SelectList(_context.LabelChecks, "Id", "CheckType", labelCheckResult.LabelCheckId);
            return View(labelCheckResult);
        }

        // POST: LabelCheckResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsSuccessful,CheckProcessStartTime,CheckProcessEndTime,Remarks,LabelCheckId")] LabelCheckResult labelCheckResult)
        {
            if (id != labelCheckResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labelCheckResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelCheckResultExists(labelCheckResult.Id))
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
            ViewData["LabelCheckId"] = new SelectList(_context.LabelChecks, "Id", "CheckType", labelCheckResult.LabelCheckId);
            return View(labelCheckResult);
        }

        // GET: LabelCheckResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelCheckResult = await _context.LabelCheckResults
                .Include(l => l.LabelCheck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelCheckResult == null)
            {
                return NotFound();
            }

            return View(labelCheckResult);
        }

        // POST: LabelCheckResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labelCheckResult = await _context.LabelCheckResults.FindAsync(id);
            _context.LabelCheckResults.Remove(labelCheckResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelCheckResultExists(int id)
        {
            return _context.LabelCheckResults.Any(e => e.Id == id);
        }

        // POST: LabelCheckResults/RunChecks
        [HttpPost, ActionName("RunChecks")]
        [ValidateAntiForgeryToken]
        public IActionResult RunChecks()
        {
            string connStr = Configuration["pspdbinfo:ConnectionString"];
            // do processing
            DateTime fromTime = DateTime.Now.AddDays(-1);
            DateTime toTime = DateTime.Now.AddDays(-1);
            string labelsConnStr = Configuration["psplabelsdbinfo:ConnectionString"];

            var jobId = BackgroundJob.Enqueue(
                () => LabelCheckUtils.ProcessAllLabelChecks(labelsConnStr, connStr, fromTime, toTime));
            return RedirectToAction(nameof(Index));
        }
    }
}