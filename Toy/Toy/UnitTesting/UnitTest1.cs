using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Program p = new Program();
            Robot myRobot = new Robot();
            myRobot.setBoard(0, 0, 4, 4);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

    }
}