using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace RobotFactory.Tests
{
    public class RobotFactoryTests
    {
        private Factory factory;
        private Robot robot;
        private Supplement supplement;
        

        [SetUp]
        public void SetUp()
        {
            
            factory = new Factory("Corrusant", 1);
            robot = new Robot("R2D2", 100, 10);
            
        }

        [Test]
        public void FactoryConstructorinitializeCorrectValues()
        {
            factory = new Factory("Corrusant",5);
            Assert.AreEqual("Corrusant", factory.Name);
            Assert.AreEqual(5, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);

        }
        [Test]
        public void FactoryConstructorinitializeForLists()
        {
            factory = new Factory("Corrusant", 5);
            Assert.AreEqual("Corrusant", factory.Name);

            factory.ProduceRobot("C-3PO", 50, 100);
            factory.ProduceSupplement("Arm", 50);

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(1, factory.Supplements.Count);

        }
        [TestCase("R2D2", 100, 10)]
        public void ProduceRobotMethodShouldWorkCorrectly(string model, double price, int interfaceStandard)
        {
            string massage = factory.ProduceRobot(model,price,interfaceStandard);

            robot = factory.Robots.FirstOrDefault();

            Assert.AreEqual($"Produced --> {robot}", massage);
            Assert.AreEqual(1, factory.Robots.Count());
        }
        [TestCase("R2D2", 100, 10)]
        public void ProduceRobotMethodShouldThrowExceptionIfCountIsMoreOrEqualToCapacity(string model, double price, int interfaceStandard)
        {
            factory.ProduceRobot(model, price, interfaceStandard);

            string massage = factory.ProduceRobot("C-3PO", 50, 100);

            Assert.AreEqual("The factory is unable to produce more robots for this production day!", massage);
        }
        [TestCase("Arm",10)]
        public void UpgradeRobotMethodShouldReturnTrue(string name,int interfaceStandard)
        {
            Supplement supplement = new Supplement(name, interfaceStandard);

            bool compatible = factory.UpgradeRobot(robot, supplement);

            Assert.IsTrue(compatible);
        }
        [TestCase("Arm", 10)]
        public void UpgradeRobotMethodShouldReturnFalseIfRobotAlreadyHasThisSupplement(string name, int interfaceStandard)
        {
            Supplement supplement = new Supplement(name, interfaceStandard);

            factory.UpgradeRobot(robot, supplement);

            bool compatible = factory.UpgradeRobot(robot, supplement);
            Assert.IsFalse(compatible);
        }
        [TestCase("Arm", 50)]
        public void UpgradeRobotMethodShouldReturnFalseIfRobotAndSupplementInterfaceStandartsAreDifferent(string name, int interfaceStandard)
        {
            Supplement supplement = new Supplement(name, interfaceStandard);

            bool compatible = factory.UpgradeRobot(robot, supplement);
            Assert.IsFalse(compatible);
        }
        [TestCase("C-3PO", 90, 10, 99)]
        public void SellMethodShouldWorkCorrectly(string model, double price, int interfaceStandard, int priceToSell)
        {
            factory = new Factory("Corrusant", 5);

            factory.ProduceRobot(model, price, interfaceStandard);
            factory.ProduceRobot("R2D2", 100, 10);
            factory.ProduceRobot("ExpensiveR2D2", 199, 10);

            Robot robotToSell = factory.SellRobot(priceToSell);

            Assert.AreEqual(model, robotToSell.Model);
            Assert.AreEqual(interfaceStandard, robotToSell.InterfaceStandard);
            Assert.True(robotToSell.Price <= priceToSell );
           

        }
    }
}