using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Links
    {
        public string user { get; set; }
        public string learning_outcome { get; set; }
        public string alignment { get; set; }
        public string assignment { get; set; }
    }

    public class OutcomeResult
    {
        public int id { get; set; }
        public bool? mastery { get; set; }
        public double? score { get; set; }
        public double? possible { get; set; }
        public double? percent { get; set; }
        public bool? hide_points { get; set; }
        public bool? hidden { get; set; }
        public DateTime submitted_or_assessed_at { get; set; }
        public Links links { get; set; }
    }

    public class Root
    {
        public List<OutcomeResult> outcome_results { get; set; }
    }
}
