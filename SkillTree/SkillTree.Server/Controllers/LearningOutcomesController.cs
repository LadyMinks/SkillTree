using Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Data;


namespace SkillTree.Server.Controllers
{
    [ApiController]
    [Route("test")]
    public class LearningOutcomesController : ControllerBase
    {

        private static readonly string[] names = new[]
        {
            "analyse", "advies", "design", "realisatie", "manage & control"
        };

        private static readonly string[] Grades = new[]
        {
            "orienting", "beginning", "proficient", "advanced"
        };

        private readonly ILogger<LearningOutcomesController> _logger;

        public LearningOutcomesController(ILogger<LearningOutcomesController> logger)
        {
            _logger = logger;
        }

        [EnableCors("MyPolicy")]
        [HttpGet(Name = "GetLearningOutcomes")]
        public IEnumerable<learningOutcome> Get()
        {
            GraphDTO graph = new GraphDTO();
            ApiDTO api = new ApiDTO();
            skillTree skilltree = new skillTree(graph, api);
            var learningOutcomes = skilltree.getLearningOutcomes();
            /*
            var i = 0;
            List<learingOutcome> learningOutcomes = new List<learingOutcome>();
            while (i < 5)
            {
                Console.WriteLine(i);
                learingOutcome learingOutcome = new learingOutcome();
                learingOutcome.name = names[i];
                learingOutcome.grade = Grades[2];
                learningOutcomes.Add(learingOutcome);
                i++;
            }
            
            var response = Enumerable.Range(1, 5).Select(index => new learingOutcome
            {
                name = learningOutcomes[index - 1].name,
                grade = learningOutcomes[index - 1].grade
            })
            .ToArray();
            */

            //Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return Enumerable.Range(1, 5).Select(index => new learningOutcome
            {
                //name = learningOutcomes[index - 1].name,
                //grade = learningOutcomes[index - 1].grade
            })
            .ToArray();

        }
    }
}