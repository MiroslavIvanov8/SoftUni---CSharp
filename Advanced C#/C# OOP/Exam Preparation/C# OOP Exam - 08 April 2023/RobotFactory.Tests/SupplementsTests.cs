using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Supplement supplement;
        [SetUp]
        public void SetUp()
        {
            supplement = new Supplement("ArtificialHand",100);

            Assert.AreEqual("ArtificialHand", supplement.Name);
            Assert.AreEqual(100, supplement.InterfaceStandard);
        }

        [Test]
        public void SupplementToStringWorksCorrectly()
        {
            Assert.AreEqual("Supplement: ArtificialHand IS: 100", supplement.ToString());
        }

    }
}