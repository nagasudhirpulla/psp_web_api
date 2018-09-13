using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabelChecksApp.Models
{
    public class CheckProcessViewModel
    {
        public DateTime CheckFromDate { get; set; }
        public long ProcessingCount { get; set; }
        public long ScheduledCount { get; set; }
        public long FailedCount { get; set; }
        public long SuccededCount { get; set; }
        public long QueuedCount { get; set; }
    }
}
