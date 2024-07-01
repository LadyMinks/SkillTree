using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MockWeatherController : IMock
    {
        public async Task<ActionResult<List<learningOutcome>>> getLearningOutcomes()
        {
            String _token = "2464~jTObAR4QZulMSgJ9GSVMwhnufYYmcpJ2qzZ55TQQ5fWfpsQgV6QX0j1pAjiIHSxU";
            String _course = "13145";
            String GraphEndpoint = "https://fhict.instructure.com/api/graphql";
            String CanvasApiEndpoint = "https://fhict.instructure.com/api/v1/courses/";
            String CanvasApiEndpointUser = "https://fhict.instructure.com/api/v1/users/self";
            GraphDTO mockgraph = new GraphDTO();
            ApiDTO mockapi = new ApiDTO();
            skillTree skilltree = new skillTree(mockgraph, mockapi);
            var learningoutcomes = await skilltree.getLearningOutcomes(_token, _course, CanvasApiEndpoint, CanvasApiEndpointUser, GraphEndpoint);
            return learningoutcomes.ToList();
        }
    }
}
