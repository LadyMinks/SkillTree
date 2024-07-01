
using Microsoft.Extensions.Logging;
using SkillTree.Server;
using SkillTree.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTree.Server;
using Logic;
using Data;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Test
{
    public class ControllerTester : ControllerBase
    {
        

       

        [Fact]
        public async Task UITest()
        {
            //Om deze test te laten slagen moet in de appsettings.json file van Skilltree.Server de volgende course worden ingevuld: "13145"

            //Arrange
            IMock controller = new MockWeatherController();
            String result = "[{\"name\":\"Analysis\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22499\",\"22504\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You can obtain desired results by analyzing the processes, products and information flows in a methodical and thorough way.</p>\\n<p>&nbsp;</p>\\n<p>Explanation:</p>\\n<ul>\\n<li>You know what you are researching and why, taking into account the client, target audience &amp; market.</li>\\n<li>Using several justified research methods based on the DOT-framework</li>\\n<li>Applying multiple different methods of analysis or focusing on several different aspects. For example: client needs, audience needs, other related products, expert knowledge, literature etc.</li>\\n</ul>\"},{\"name\":\"Advice\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22503\",\"22500\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p><span lang=\\\"EN-US\\\">You can give advice about the organization, processes and/or information important for decisions related to your challenge. Your advice is based on the conclusions and results from the analysis. Your advice can be based on cost aspects and quality properties such as: availability, performance, security and scalability.</span></p>\"},{\"name\":\"Design\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22549\",\"22536\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You are able to design (parts of) systems, communicate and validate about it for both functional/technical and aesthetic requirements using industry standard methods, related to your challenge.</p>\\n<p><span><br></span>Explanation:</p>\\n<ul>\\n<li>With&nbsp;design we mean that you can use a structured and methodical approach in your design. You use a set of concept development methods such as diverging/converging, brainstorms and existing theories as well as structured technical design methods such as UML and RUP.</li>\\n<li>The&nbsp;design&nbsp;covers both the functional/technical and aesthetic design of your products. You&nbsp;communicate&nbsp;your design in a well presented and structured way to relevant stakeholders.</li>\\n<li>You&nbsp;validate&nbsp;your designed&nbsp;systems&nbsp;in an early stage using efficient and quick prototyping methods such as paper prototyping and use the results to refine your design.</li>\\n</ul>\"},{\"name\":\"Realization\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22540\",\"22553\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You can implement and&nbsp;validate&nbsp;a product&nbsp;based on a design in a&nbsp;structured way&nbsp;using&nbsp;innovative and/or relevant technology&nbsp;adhering to&nbsp;quality criteria&nbsp;in the context of your challenge.</p>\\n<p>&nbsp;</p>\\n<p>Explanation:</p>\\n<ul>\\n<li>We expect that youvalidate&nbsp;your product and the quality of the product in a structured way using methods such as:&nbsp; User testing, expert reviews, code/peer reviews, (unit) tests.</li>\\n<li>Structured waymeans using industry standard development processes such as Scrum/Agile and Kanban.</li>\\n<li>Withinnovative and/or relevant technology&nbsp;we mean that you experiment and use upcoming and promising technology that suits your needs.</li>\\n<li>Your product adheres to previously definedquality criteria&nbsp;in accordance with stakeholders. Many non-functional requirements such as stability, performance, security etc. could be used to define these criteria.</li>\\n</ul>\"},{\"name\":\"Manage and control\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22546\",\"22555\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You can perform activities that focus on control, monitoring and optimization of the development, commissioning and use of ICT-systems. These activities are related to your challenge.</p>\\n<p>&nbsp;</p>\\n<p>Explanation:</p>\\n<ul>\\n<li>We expect that you build your controlling, monitoring and optimalisation of the development in a structured way.</li>\\n<li>We expect that you can communicate with stakeholders about your activities who are related to manage and control.</li>\\n</ul>\"},{\"name\":\"Future oriented organization\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22547\",\"22541\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You are able to show that you explore the organisational context of ICT assignments, make business, sustainable and ethical considerations and manage all aspects of the execution of the assignment.</p>\"},{\"name\":\"Investigative Problem Solving\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22550\",\"22554\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You are able to taking a critical look at ICT assignments from different perspectives, identifying problems, finding an effective approach and arriving at appropriate solutions.</p>\"},{\"name\":\"Personal Leadership\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22556\",\"22548\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You are able to show that you are being entrepreneurial around ICT assignments and personal development, paying attention to one's own learning ability and keeping in mind what kind of ICT professional and/or what type of positions one aspires to.</p>\"},{\"name\":\"Targeted Interaction\",\"grade\":\"Proficient\",\"outcomeIds\":[\"22552\",\"22537\"],\"lastsubmission\":\"2024-01-21T18:17:26Z\",\"description\":\"<p>You are able to determine which partners play a role in the ICT assignment, collaborate constructively with them and communicate appropriately to achieve the desired impact.</p>\"}]";
            List<learningOutcome> outcomes = JsonSerializer.Deserialize<List<learningOutcome>>(result);
            var testJSON = outcomes.ToList();

            //Act
            var test = await controller.getLearningOutcomes();
            int whileloops = test.Value.Count;
            int i = 0;


            //Assert
            while (i < whileloops)
            {
                Assert.Equal(test.Value[i].ToString(), outcomes[i].ToString());
                i++;
            }
        }
    }
}
