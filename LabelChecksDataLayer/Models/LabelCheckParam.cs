using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheckParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public int LabelCheckId { get; set; }
        public LabelCheck LabelCheck { get; set; }
    }
}
