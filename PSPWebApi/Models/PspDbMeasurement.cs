using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSPWebApi.Models
{
    public class PspDbMeasurement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string PspTable { get; set; }
        [Required]
        public string PspValCol { get; set; }
        public string PspTimeCol { get; set; }

        public string EntityCol { get; set; }
        public string EntityVal { get; set; }

        public string SqlStr { get; set; }
        public string QueryParams { get; set; }
        public string QueryParamVals { get; set; }
    }
}
