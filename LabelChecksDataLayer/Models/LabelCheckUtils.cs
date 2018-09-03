using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheckUtils
    {
        public static readonly List<string> CheckTypes = new List<string> { CheckTypeNotNull, CheckTypeNotBlank, CheckTypeNumeric, CheckTypeLimit, CheckTypeDevPercLimit };

        public const string CheckTypeNotNull = "not_null";
        public const string CheckTypeNotBlank = "not_blank";
        public const string CheckTypeNumeric = "is_numeric";
        public const string CheckTypeLimit = "limit";
        public const string CheckTypeDevPercLimit = "perc_dev_limit";

        public static readonly DateTime DefaultCheckConsiderStartTime = DateTime.Parse("2018-01-01");
        public static readonly DateTime DefaultCheckConsiderEndTime = DateTime.Parse("2030-01-01");
    }
}
