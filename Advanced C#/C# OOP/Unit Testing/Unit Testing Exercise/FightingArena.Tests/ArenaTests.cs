namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior jarvis;
        private Warrior clark;
        private Warrior miro;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
           jarvis = new Warrior("Jarvis", 50, 50);
           clark = new Warrior("Clark", 100, 100);
           miro = new Warrior("Miro", 150, 150);

           arena = new Arena();
        }
        [Test]
        public void ConstuctorInitializeArenaCorrectly()
        {
            Arena arena = new Arena();

            arena.Enroll(jarvis);
            arena.Enroll(clark);
            arena.Enroll(miro);

            Assert.AreEqual(3, arena.Count);
        }

        [Test]
        public void ArenaEnrollMethodSHouldThrowExceptionWhenEnlistedWarriorEnrolsAgain()
        {
            Arena arena = new Arena();

            arena.Enroll(jarvis);
            arena.Enroll(clark);
            arena.Enroll(miro);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(jarvis));
            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void ArenaIsImplementedAsIReadOnlyCollectionCorrectly()
        {
            Arena arena = new Arena();

            arena.Enroll(jarvis);
            arena.Enroll(clark);
            arena.Enroll(miro);

            foreach (Warrior warrior in arena.Warriors)
            {
                Console.WriteLine(warrior.Name);
            }
        }
        [Test]
        public void ArenaFightMethodShouldWorkCorrectly()
        {
            
            Warrior conor = new Warrior("Conor", 10, 100);
            Warrior aldo = new Warrior("Aldo", 5, 100);

            arena.Enroll(conor);
            arena.Enroll(aldo);

            arena.Fight("Conor", "Aldo");

            Assert.AreEqual(conor.HP, 95);
            Assert.AreEqual(aldo.HP, 90);

        }
        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfAttackerkIsNull()
        {

            Warrior conor = new Warrior("Conor", 10, 100);
            Warrior aldo = new Warrior("Aldo", 5, 100);

            arena.Enroll(conor);
            arena.Enroll(aldo);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()=>arena.Fight("Josh", "Aldo"));

            Assert.AreEqual("There is no fighter with name Josh enrolled for the fights!", ex.Message);

        }

        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfDefenderkIsNull()
        {

            Warrior conor = new Warrior("Conor", 10, 100);
            Warrior aldo = new Warrior("Aldo", 5, 100);

            arena.Enroll(conor);
            arena.Enroll(aldo);
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Conor", "Josh"));

            Assert.AreEqual("There is no fighter with name Josh enrolled for the fights!", ex.Message);

        }
    }
}
