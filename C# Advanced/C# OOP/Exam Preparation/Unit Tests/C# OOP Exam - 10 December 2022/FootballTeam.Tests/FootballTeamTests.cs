using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        private FootballPlayer player;
        private FootballTeam team;
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("Bulgaria", 21);
            player = new FootballPlayer("HristoStoyckov",9,"Forward");
        }
        [TestCase("Bulgaria", 21)]        
        public void ConstructorInitializeCorrectValues(string name, int capacity)
        {
            team = new FootballTeam(name,capacity);

            Assert.AreEqual(name, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
            Assert.AreEqual(team.Players.Count, 0);

        }
        [TestCase("", 21)]
        [TestCase(null, 21)]
        public void ConstructorShouldThrowExceptionIfNameIsNullOrEmpty(string name, int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => team = new FootballTeam(name,capacity));

            Assert.AreEqual("Name cannot be null or empty!", ex.Message);

        }
        [TestCase("Bulgaria", 14)]
        [TestCase("Bulgaria", 10)]
        public void ConstructorShouldThrowExceptionIfCapacityIsLessThan15(string name, int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, capacity));

            Assert.AreEqual("Capacity min value = 15", ex.Message);

        }
        [Test]
        public void AddplayerMethodShouldWorkCorrectly()
        {
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", team.AddNewPlayer(player));

        }
        [TestCase("Bulgaria", 15)]
        public void AddplayerMethodShouldThrowExceptionIfCountIsMoreThanCapacity(string name, int capacity)
        {
            team = new FootballTeam(name, capacity);
            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
            }
            string massage = team .AddNewPlayer(player);

            Assert.AreEqual("No more positions available!", massage);

        }
        [TestCase("HristoStoyckov")]
        public void PickMethodShouldWorkCorrectly(string name)
        {
            team.AddNewPlayer(player);
            FootballPlayer correctPlayer = team.PickPlayer(name);

            Assert.AreSame(correctPlayer, player);
        }
        [TestCase("Hristo")]
        public void PickMethodShouldThrowNullExcpetion(string name)
        {
            team.AddNewPlayer(player);
            FootballPlayer correctPlayer = team.PickPlayer(name);

            Assert.AreSame(correctPlayer, null);
        }
        [TestCase("9")]
        public void PlayerScoreShoudlWorkCorrectly (int number)
        {
            team.AddNewPlayer(player);
            string message = team.PlayerScore(9);
            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals} for this season!", message);
        }
        [Test]
        public void PlayerScoreShoudlShouldThrowNullException()
        {
            NullReferenceException ex = Assert.Throws<NullReferenceException>(()=> team.PlayerScore(9));
            Assert.AreEqual($"Object reference not set to an instance of an object.", ex.Message);
        }
    }
}

