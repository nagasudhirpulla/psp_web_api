using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSPDataFetchLayer.Models;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheck
    {
        public int Id { get; set; }
        public string CheckType { get; set; }
        public int? Num1 { get; set; }
        public int? Num2 { get; set; }
        public DateTime ConsiderStartTime { get; set; }
        public DateTime ConsiderEndTime { get; set; }

        public PspMeasurement PspMeasurement { get; set; }
        public int PspMeasurementId { get; set; }
    }
}
