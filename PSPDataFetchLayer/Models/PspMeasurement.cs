using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSPDataFetchLayer.Models
{
    public class PspMeasurement
    {
        public int MeasId { get; set; }
        public string Label { get; set; }
        public string PspTable { get; set; }
        public string PspValCol { get; set; }
        public string PspTimeCol { get; set; }

        public string EntityCol { get; set; }
        public string EntityVal { get; set; }

        public string SqlStr { get; set; }
        public string QueryParams { get; set; }
        public string QueryParamVals { get; set; }
    }
}
