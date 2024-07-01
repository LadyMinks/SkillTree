using Logic;

namespace Test
{
    public class GradeCheckTester
    {
        [Fact]
        public void GradeCheckTest1()
        {
            //Arange
            IGradeCheck gradechecker = new GradeCheck();
            learningOutcome mock = new learningOutcome("mockname", "mockdescription");
            mock.changelastsubmission(DateTime.Now);

            //Act
            bool actual = gradechecker.gradecheck(mock.lastsubmission, DateTime.Now.AddMinutes(5));

            //Asert
            Assert.Equal(true, actual);

        }
        [Fact]
        public void GradeCheckTest2()
        {
            //Arange
            IGradeCheck gradechecker = new GradeCheck();
            learningOutcome mock = new learningOutcome("mockname", "mockdescription");
            mock.changelastsubmission(DateTime.Now);

            //Act
            bool actual = gradechecker.gradecheck(mock.lastsubmission, DateTime.Now.AddMinutes(-5));

            //Asert
            Assert.Equal(false, actual);

            
        }

        [Fact]
        public void GradeCheckTest3()
        {
            //Arange
            IGradeCheck gradechecker = new GradeCheck();
            learningOutcome mock = new learningOutcome("mockname", "mockdescription");
            var now = DateTime.Now;
            mock.changelastsubmission(now);

            //Act
            bool actual = gradechecker.gradecheck(mock.lastsubmission, now);

            //Asert
            Assert.Equal(false, actual);
        }
    }
}