using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Logic
{
    public interface IMock
    {
        public Task<ActionResult<List<learningOutcome>>> getLearningOutcomes();
    }
}
