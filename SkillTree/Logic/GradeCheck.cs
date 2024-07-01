using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GradeCheck :IGradeCheck
    {
        public bool gradecheck(DateTime? lastsubmission, DateTime submitted_or_assessed_at)
        {
            bool outcome;
            if (lastsubmission == null)
            {
                outcome = true;
            }
            else
            {
                if(lastsubmission < submitted_or_assessed_at)
                {
                    outcome = true;
                }
                else
                {
                    outcome = false;
                }
            }
            return outcome;
        }
    }
}
