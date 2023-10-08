using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class RobotTests
    {
        private Robot robot;
        private Supplement supplement;

        [Test]
        public void RobotConstructorinitializeCorrectValues()
        {
            robot = new Robot("R2D2", 110, 500);
            Assert.AreEqual("R2D2", robot.Model);
            Assert.AreEqual(110, robot.Price);
            Assert.AreEqual(500, robot.InterfaceStandard);

        }
        [Test]
        public void RobotConstructorinitializeWorkingList()
        {
            robot = new Robot("R2D2", 110, 500);
            supplement = new Supplement("Arm", 100);

            robot.Supplements.Add(supplement);

            Assert.AreEqual(1, robot.Supplements.Count);

        }
        [Test]
        public void RobotToStringWorksCorrectly()
        {
            robot = new Robot("R2D2", 110, 500);
            Assert.AreEqual($"Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}", robot.ToString());
        }

    }
}