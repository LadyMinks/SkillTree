using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IApiDTO
    {
        public Task<List<learningOutcome>> getCourseGrades(List<learningOutcome> learningOutcomes, String token, String course, String apiendpoint, String apiendpointuser);

       
    }
}
