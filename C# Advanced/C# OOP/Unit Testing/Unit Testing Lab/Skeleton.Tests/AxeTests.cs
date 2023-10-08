using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [TestCase(100,100)]
        public void AxeConstructionInitializeCorrect(int axeAtt, int axeDura)
        {
            //Arrange and Act
            Axe axe = new Axe(axeAtt, axeDura);

            //Assert 
            Assert.AreEqual(100,axeAtt);
            Assert.AreEqual(100, axeDura);
        }
        [TestCase(20,10)]
        public void DurabilityLossTest(int axeAtt, int axeDura)
        {
            //Arrange
            Axe axe = new Axe(axeAtt, axeDura);
            Dummy target = new Dummy(40,10);

            //Act
            axe.Attack(target);

            //Assert
            Assert.AreEqual(axeDura-1, axe.DurabilityPoints);
            
        }
        [TestCase(10,10)]
        public void AttackMethodWithBrokenWeaponShouldThrowAnException(int axeAtt, int axeDura)
        {
            //Arrange
            Axe axe = new Axe(axeAtt, axeDura);
            Dummy target = new Dummy(100, 10);

            //Act
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(target);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(target),
                "Axe is broken");                
        }
    }
}