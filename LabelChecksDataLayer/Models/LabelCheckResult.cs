using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheckResult
    {
        // todo CheckProcessStartTime, CheckProcessEndTime, LabelCheckId should be unique
        public int Id { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CheckProcessStartTime { get; set; }
        public DateTime CheckProcessEndTime { get; set; }
        public string Remarks { get; set; }

        public int LabelCheckId { get; set; }
        public virtual LabelCheck LabelCheck { get; set; }
    }
}
