using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GraphQL;

namespace Test
{
    public class GraphQLTester
    {
        private const string GraphQLEndpointURL = "https://fhict.instructure.com/api/graphql";
        public string accessToken = "2464~jTObAR4QZulMSgJ9GSVMwhnufYYmcpJ2qzZ55TQQ5fWfpsQgV6QX0j1pAjiIHSxU";
        internal string courseid = "13145";

        [Fact]
        public async Task TestGraphQLConnection()
        {
            //Arrange
            bool statuscode = true;
            var graphQlClient =
            new GraphQLHttpClient(GraphQLEndpointURL, new NewtonsoftJsonSerializer());
            graphQlClient.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);
            var query = new GraphQLRequest
            {
                Query = $@"
                    query MyQuery {{
                        course(id: ""{courseid}"") {{
                            id
                            name
                            _id
                        }}
                    }}
                }}"
            };

            //Act
            var response = await graphQlClient.SendQueryAsync<JObject>(query);
            var courseinfo = response.Data["course"];
            String course = $"{courseinfo["_id"]}";

            //Assert
            Assert.Equal(courseid,course);
        }
        
    }
}
