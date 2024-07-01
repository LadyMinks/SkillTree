using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;




namespace Data
{
    public class ApiDTO : IApiDTO
    {
        private string CanvasApiEndpoint;
        private string CanvasApiEndpointUser;
        private string _accessToken;
        private string _courseid;

        public List<OutcomeResult> outcomes = new List<OutcomeResult>();

        public async Task<List<learningOutcome>> getCourseGrades(List<learningOutcome> learningOutcomes, String token, String course, String apiendpoint, String apiendpointuser)
        {
            this._accessToken = token;
            this._courseid = course;
            this.CanvasApiEndpoint = apiendpoint;
            this.CanvasApiEndpointUser = apiendpointuser;
            User user = await GetSelf(_accessToken, CanvasApiEndpointUser);
            await getAPILearningOutcomes(learningOutcomes, user);
            return learningOutcomes;
        }

        private async Task<User> GetSelf(String token, String endpoint)
        {
            User user = new User();
            var userclient = new HttpClient();
            userclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await userclient.GetStringAsync(endpoint);
            user = JsonSerializer.Deserialize<User>(response);
            return user;
        }

        private async Task getAPILearningOutcomes(List<learningOutcome> outcomes, User user)
        {
            foreach (var outcome in outcomes)
            {
                var outcomestring = "";
                var idList = outcome.outcomeIds;
                foreach (var id in idList)
                {
                    if (outcomestring == "")
                    {
                        outcomestring = id;
                    }
                    else
                    {
                        outcomestring = outcomestring + "," + id;
                    }
                }
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._accessToken );
                var OutcomeResponse = await client.GetStringAsync(CanvasApiEndpoint + this._courseid +
                                                                  "/outcome_results/?user_ids=" + user.id +
                                                                  "&outcome_ids=" + outcomestring);
                try
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(OutcomeResponse);
                    foreach (var score in myDeserializedClass.outcome_results)
                    {
                        if (outcome.outcomeIds.Any(s => s.Contains(score.links.learning_outcome)))
                        {
                            IGradeCheck gradeCheck = new GradeCheck();
                            if (gradeCheck.gradecheck(outcome.lastsubmission, score.submitted_or_assessed_at))
                            {
                                outcome.changelastsubmission(score.submitted_or_assessed_at);
                                GradeAdder gradeadder = new GradeAdder();
                                gradeadder.changegrade(score.score, outcome);
                            }
                        }
                    }
                }
                catch
                {
                    
                }
            }
        }        
    }
}
