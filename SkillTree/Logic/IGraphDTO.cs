using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IGraphDTO
    {
        public Task<List<learningOutcome>> GetLearningOutcomes(String token, String course, String graphendpoint);

        
    }
}
