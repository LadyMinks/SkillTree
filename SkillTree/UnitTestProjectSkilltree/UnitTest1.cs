using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Logic;




namespace UnitTestProjectSkilltree
{
    [TestClass]
    public class GradeCheckTester
    {
        [Fact]
        public void gradetest1()
        {
            IGradeCheck gradecheck = new GradeCheck();
            gradecheck.gradecheck(){

            }
        }
    
    }
}
