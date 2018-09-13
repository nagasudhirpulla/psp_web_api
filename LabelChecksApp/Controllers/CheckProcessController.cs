using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Storage;
using LabelChecksApp.Models;
using LabelChecksDataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LabelChecksApp.Controllers
{
    public class CheckProcessController : Controller
    {
        private readonly LabelChecksDbContext _context;
        private IConfiguration Configuration { get; }

        public CheckProcessController(LabelChecksDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: CheckProcess
        public ActionResult Index(string dateStr)
        {
            // get the hangfire job statistics
            long processingCount = JobStorage.Current.GetMonitoringApi().ProcessingCount();
            long scheduledCount = JobStorage.Current.GetMonitoringApi().ScheduledCount();
            long queuesCount = JobStorage.Current.GetMonitoringApi().Queues().Count;
            long succededCount = 0;
            long failedCount = 0;
            try
            {
                succededCount = JobStorage.Current.GetMonitoringApi().SucceededByDatesCount()[DateTime.Now.Date];
            }
            catch (KeyNotFoundException) { /* do nothing  */ }
            try
            {
                failedCount = JobStorage.Current.GetMonitoringApi().FailedByDatesCount()[DateTime.Now.Date];
            }
            catch (KeyNotFoundException) { /* do nothing  */ }

            CheckProcessViewModel checkProcessViewModel = new CheckProcessViewModel { CheckFromDate = DateTime.Now.AddDays(-1).Date, ProcessingCount = processingCount, ScheduledCount = scheduledCount, QueuedCount = queuesCount, SuccededCount = succededCount, FailedCount = failedCount };

            if (!string.IsNullOrEmpty(dateStr))
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    checkProcessViewModel.CheckFromDate = dt;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unexpected date format found in the page load request");
                }
            }
            return View(checkProcessViewModel);
        }

        // POST: CheckProcess/CheckProcess
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckProcess(CheckProcessViewModel checkProcessViewModel)
        {
            try
            {
                string connStr = Configuration["pspdbinfo:ConnectionString"];
                // do processing
                DateTime fromTime = checkProcessViewModel.CheckFromDate;
                DateTime toTime = checkProcessViewModel.CheckFromDate;
                string labelsConnStr = Configuration["psplabelsdbinfo:ConnectionString"];

                var jobId = BackgroundJob.Enqueue(
                    () => LabelCheckUtils.ProcessAllLabelChecks(labelsConnStr, connStr, fromTime, toTime));

                //return Redirect("~/hangfire");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}