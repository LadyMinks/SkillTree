using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class skillTree
    {
       

        private IGraphDTO grapher;
        public IApiDTO api;

        public skillTree(IGraphDTO graphql, IApiDTO api)
        {
            this.grapher = graphql;
            this.api = api;
        }


        public async Task<List<learningOutcome>> getLearningOutcomes(String token, String course, String _apiEndpoint, String _apiEndpointUser, String _graphEndpoint)
        {
            
            var returnlist = await this.grapher.GetLearningOutcomes(token, course, _graphEndpoint);
            await this.api.getCourseGrades(returnlist,token,course, _apiEndpoint, _apiEndpointUser);
            
            //foreach (var learningOutcome in returnlist)
            //{
            //    learningOutcome.name = learningOutcome.name.Substring(2);
            //}
            return returnlist;
        }
    }
}
