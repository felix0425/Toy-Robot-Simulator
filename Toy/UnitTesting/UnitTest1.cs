using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void testInit()
        {
            Program p = new Program();
            Robot myRobot = new Robot();
            myRobot.setBoard(0, 0, 4, 4);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
