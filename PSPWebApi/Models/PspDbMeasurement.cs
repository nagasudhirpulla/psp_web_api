using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSPWebApi.Models
{
    public class PspDbMeasurement
    {
        [Required]
        public int ID  { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string TableName { get; set; }
        public string TimeColName { get; set; }
        [Required]
        public string ValColName { get; set; }
    }
}
