using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace SkillTree.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase, IMock
    {
        private readonly IConfiguration _configuration;
        private readonly String _token;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGraphDTO _graphDTO;
        private readonly String _course;
        private readonly IApiDTO _apiDTO;
        private readonly String _graphEndpoint;
        private readonly String _apiEndpoint;
        private readonly String _apiEndpointUser;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IGraphDTO graphDTO, IConfiguration configuration, IApiDTO apiDTO)
        {
            _logger = logger;
            _graphDTO = graphDTO;
            _configuration = configuration;
            _token = configuration["token"];
            _course = configuration["course"];
            _apiDTO = apiDTO;
            _graphEndpoint = configuration["GraphEndpoint"];
            _apiEndpoint = configuration["CanvasApiEndpoint"];
            _apiEndpointUser = configuration["CanvasApiEndpointUser"];
        }

        [HttpGet(Name = "Getweatherforecast")]
        public async Task<ActionResult<List<learningOutcome>>> getLearningOutcomes()
        {          
            skillTree skilltree = new skillTree(this._graphDTO, this._apiDTO);
            var learningoutcomes = await skilltree.getLearningOutcomes(_token,_course,_apiEndpoint,_apiEndpointUser,_graphEndpoint);       
            return learningoutcomes.ToList();
        }
    }
}
