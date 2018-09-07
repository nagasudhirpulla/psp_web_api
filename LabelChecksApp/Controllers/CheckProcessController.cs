using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabelChecksApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabelChecksApp.Controllers
{
    public class CheckProcessController : Controller
    {
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
                // TODO: Add insert logic here
                return Redirect("~/hangfire");
            }
            catch
            {
                return View();
            }
        }        
    }
}