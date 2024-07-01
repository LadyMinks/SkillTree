using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Logic
{
    public class GradeAdder
    {
        public void changegrade(double? grade, learningOutcome outcome)
        {
            if (grade != null && grade != 0 && grade < 5)
            {
                if (grade == 1)
                {
                    outcome.changegrade("Orienting");
                }
                else if (grade == 2)
                {
                    outcome.changegrade("Beginning");
                }
                else if (grade == 3)
                {
                    outcome.changegrade("Proficient");
                }
                else
                {
                    outcome.changegrade("Advanced");
                }
            }
        }
    }
}
