using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballPlayerTests
    {
        private FootballPlayer player;
        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("HristoStoyckov",9,"Forward");
        }

        [TestCase("HristoStoyckov", 9, "Forward")]
        [TestCase("HristoStoyckov", 9, "Midfielder")]
        [TestCase("HristoStoyckov", 9, "Goalkeeper")]
        public void ConstructorInitializeCorrectValues(string name, int number,string position)
        {
            player = new FootballPlayer(name, number, position);
            
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(number, player.PlayerNumber);
            Assert.AreEqual(position, player.Position);
            Assert.AreEqual(player.ScoredGoals, 0);
           
        }
        [TestCase("", 9, "Forward")]
        [TestCase(null, 9, "Midfielder")]        
        public void ConstructorShouldThrowExceptionIfNameIsNullOrEmpty(string name, int number, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => player = new FootballPlayer(name, number, position));

            Assert.AreEqual("Name cannot be null or empty!", ex.Message);

        }
        [TestCase("HristoStoyckov", 0, "Forward")]
        [TestCase("HristoStoyckov", 22, "Midfielder")]
        public void ConstructorShouldThrowExceptionIfNumberIsNotInTheGivenRange(string name, int number, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => player = new FootballPlayer(name, number, position));

            Assert.AreEqual("Player number must be in range [1,21]", ex.Message);

        }
        [TestCase("HristoStoyckov", 1, "Kek")]
        [TestCase("HristoStoyckov", 11, "Dont know what to do")]
        public void ConstructorShouldThrowExceptionIfPositionIsNotSupported(string name, int number, string position)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => player = new FootballPlayer(name, number, position));

            Assert.AreEqual("Invalid Position", ex.Message);

        }

        [Test]
        public void ScoreMethodShouldWorkCorrectly()
        {
            player.Score();
            player.Score();
            player.Score();

            Assert.AreEqual(player.ScoredGoals, 3);

        }
    }
}
