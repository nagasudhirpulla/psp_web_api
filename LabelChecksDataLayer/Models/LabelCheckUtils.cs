using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheckUtils
    {
        public const string CheckTypeNotNull = "not_null";
        public const string CheckTypeNotBlank = "not_blank";
        public const string CheckTypeNumeric = "is_numeric";
        public const string CheckTypeLimit = "limit";
        public const string CheckTypeDevPercLimit = "perc_dev_limit";
    }
}
