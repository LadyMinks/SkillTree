using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using GraphQL;


namespace Data
{
    public class GraphDTO : IGraphDTO
    {
        private string GraphQLEndpointURL;
        private string accessToken;
        private string courseid;

        


        public async Task<List<learningOutcome>> GetLearningOutcomes(String token, String course, String graphEndpoint)
        {
            var i = 0;
            this.accessToken = token;
            this.courseid = course;
            this.GraphQLEndpointURL = graphEndpoint;
            List<learningOutcome> learningoutcomes = new List<learningOutcome>();
            /*while (i < 5)
            {
                learningOutcome learingOutcome = new learningOutcome();
                learingOutcome.name = names[i];
                learingOutcome.grade = Grades[2];
                learningoutcomes.Add(learingOutcome);
                i++;
            }*/
            await this.getGraphLearningOutcomes(learningoutcomes);
            return learningoutcomes;
        }



        private async Task getGraphLearningOutcomes(List<learningOutcome> outcomes)
        {
            
            var graphQlClient =
            new GraphQLHttpClient(GraphQLEndpointURL, new NewtonsoftJsonSerializer());
            graphQlClient.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            
            var query = new GraphQLRequest
            {
                Query = $@"
                query MyQuery {{
                    course(id: {courseid}) {{
                    name
                        rubricsConnection {{
                            edges {{
                                node {{
                                    _id
                                    hasRubricAssociations
                                    criteria {{
                                        longDescription
                                         outcome {{
                                            _id
                                            title
                                            pointsPossible
                                            description
                                         }}  
                                    }}
                                }}
                            }}
                        }}           
                   }}
                }}"
            };
            var response = await graphQlClient.SendQueryAsync<JObject>(query);
            var courseinfo = response.Data["course"];
            var rubricsConnection = courseinfo["rubricsConnection"];
            var edges = rubricsConnection["edges"];
            if (courseinfo != null)
            {
                foreach (var node in edges)
                {
                    var inode = node["node"];
                    var usenode = $"{inode["hasRubricAssociations"]}";
                    if (usenode == "True")
                    {
                        var criteria = inode["criteria"];
                        foreach (var outcome in criteria)
                        {
                            var ioutcome = outcome["outcome"];
                            var useoutcome = $"{ioutcome["pointsPossible"]}";
                            if (useoutcome == "4")
                            {
                                learningOutcome outcomeobjectfound = outcomes.Find(x => x.name == $"{ioutcome["title"]}".Substring(2));

                                if (outcomeobjectfound != null)
                                {
                                    string oid = $"{ioutcome["_id"]}";
                                    bool exists = outcomeobjectfound.outcomeIds.Any(s => s.Contains(oid));
                                    if (!exists)
                                    {

                                        outcomeobjectfound.addOutcomeIds(oid);
                                    }
                                }
                                else
                                {
                                    learningOutcome outcomeobject = new learningOutcome($"{ioutcome["title"]}", $"{ioutcome["description"]}");
                                    
                                    //outcomeobject.description = $"{ioutcome["description"]}";
                                    ////outcomeobject.grade = "unknown";
                                    //outcomeobject.name = $"{ioutcome["title"]}";
                                    string oid = $"{ioutcome["_id"]}";
                                    outcomeobject.addOutcomeIds(oid);
                                    outcomes.Add(outcomeobject);
                                }
                            }
                            
                        }
                    }
                    
                }
            }


        }



        
    }
}
