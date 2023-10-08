using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyConstuctionInitializeCorrectly()
        {
            //Assert and Act
            Dummy target = new Dummy(100, 100);

            Assert.AreEqual(100, target.Health);

        }
        [Test]
        public void TakeDamageMethodCorrectHealthDecrease()
        {
            //Arrange 
           
            Dummy target = new Dummy(100, 100);

            //Act
            target.TakeAttack(100);

            //Assert            
            Assert.AreEqual(0,0);
        }
        [Test]
        public void TakeDamageMethodBringsHealthToZero()
        {
            //Arrange
             Dummy target = new Dummy(10, 100);

            //Act
            target.TakeAttack(10);

            //Assert            
            Assert.Throws<InvalidOperationException>(
                () => target.TakeAttack(10), "Dummy is dead.");            
        }
        [Test]
        public void GiveExperienceMethodWithZeroHP()
        {
            //Arrange
            
            Dummy target = new Dummy(100, 100);

            //Act
            target.TakeAttack(100);

            //Assert
            Assert.AreEqual(100,target.GiveExperience());
            
        }
        [Test]
        public void GiveExperienceMethodWithMoreHpThanZero()
        {
            //Arrange            
            Dummy target = new Dummy(200, 100);

            //Act
            target.TakeAttack(100);

            //Assert
            Assert.Throws<InvalidOperationException>(
                 () => target.GiveExperience(), "Target is not dead.");
        }
        [Test]
        public void IsDeadMethodCorrectChange()
        {
            //Arrange            
            Dummy target = new Dummy(100, 100);


            //Act
            target.TakeAttack(100);

            //Assert
            Assert.True(target.IsDead());
        }
    }
}