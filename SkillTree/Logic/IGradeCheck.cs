using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IGradeCheck
    {
        public bool gradecheck(DateTime? lastsubmission, DateTime submitted_or_assessed_at);
    }
}
