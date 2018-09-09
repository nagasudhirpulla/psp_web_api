using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
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
        public ActionResult Index()
        {
            return View();
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

                return Redirect("~/hangfire");
            }
            catch
            {
                return View();
            }
        }        
    }
}