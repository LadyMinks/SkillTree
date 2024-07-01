using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class GradeAdderTester
    {
        [Fact]
        public void GradeAdderTestOrienting()
        {
            //Arrange
            learningOutcome mock = new learningOutcome("mockname","mockdescription");
            GradeAdder addermock = new GradeAdder();
            Double grade = 1;
            String result = "Orienting";

            //Act
            addermock.changegrade(grade,mock);

            //Assert
            Assert.Equal(result, mock.grade);
        }

        [Fact]
        public void GradeAdderTest5()
        {
            //Arrange
            learningOutcome mock = new learningOutcome("mockname", "mockdescription");
            GradeAdder addermock = new GradeAdder();
            Double grade = 5;
            

            //Act
            addermock.changegrade(grade, mock);

            //Assert
            Assert.Equal(null, mock.grade);
        }

        [Fact]
        public void GradeAdderTest0()
        {
            //Arrange
            learningOutcome mock = new learningOutcome("mockname", "mockdescription");
            GradeAdder addermock = new GradeAdder();
            Double grade = 0;
            

            //Act
            addermock.changegrade(grade, mock);

            //Assert
            Assert.Equal(null, mock.grade);
        }

        
    }
}
