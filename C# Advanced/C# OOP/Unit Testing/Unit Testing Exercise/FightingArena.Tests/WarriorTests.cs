namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Bob", 10, 10);
        }

        [TestCase("Jarvis",50,100)]
        public void WarriorConstuctorSettingCorrectValues(string name,int dmg,int hp)
        {
            Warrior warrior = new(name,dmg,hp);

            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.HP, hp);
            Assert.AreEqual(warrior.Damage, dmg);
        }

        [TestCase(" ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("", 50, 100)]
        public void WarriorConstuctorThrowingExceptionWhenNameIsWhitespaceNullOrEmpty(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new(name, dmg, hp), "Name should not be empty or whitespace!");
        }

        [TestCase("Jake Paul", 0, 100)]
        [TestCase("Jake Paul", -10, 100)]
        public void WarriorConstuctorThrowingExceptionWhenDamageIsZeroOrNegative(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new(name, dmg, hp), "Damage value should be positive!");
        }
        
        [TestCase("Jake Paul", 10, -100)]
        public void WarriorConstuctorThrowingExceptionWhenHealthIsNegative(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new(name, dmg, hp), "HP should not be negative!");
        }

        [TestCase("Jake Paul", 31, 100)]
        public void AttackMethodShouldThrowExceptionWhenHisHPIsLowerThanMinHPToAttack(string name, int dmg, int hp)
        {
            Warrior target = new Warrior(name, dmg, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase("Jake Paul", 30, 29)]
        [TestCase("Jake Paul", 30, 30)]
        public void AttackMethodShouldThrowExceptionWhenHisTargetHPIsLowerThanMinHPToAttack(string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 31, 31);
            Warrior target = new Warrior(name, dmg, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target), $"Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase("Jake Paul", 50, 50)]
        public void AttackMethodShouldThrowExceptionWhenHisAttackIsLowerThanHisTargets(string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 31, 31);
            Warrior target = new Warrior(name, dmg, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target), $"You are trying to attack too strong enemy");
        }

        [TestCase("Jake Paul", 50, 50)]
        public void AttackMethodShouldDecreaseHisHPCorrectly(string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 100, 100);
            Warrior target = new Warrior(name, dmg, hp);
            warrior.Attack(target);
            Assert.AreEqual(50,warrior.HP);
        }

        [TestCase("Jake Paul", 50, 50)]
        public void AttackMethodWhereAttackersAttIsMoreThanTargetHPShouldDropTargetHPToZEro (string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 100, 100);
            Warrior target = new Warrior(name, dmg, hp);
            warrior.Attack(target);
            Assert.AreEqual(0, target.HP);
        }

        [TestCase("Jake Paul", 50, 150)]        
        public void AttackMethodWhereAttackersAttIsLessThanTargetHPShouldDecreaseTargetHPCorrectly(string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 100, 100);
            Warrior target = new Warrior(name, dmg, hp);
            warrior.Attack(target);
            Assert.AreEqual(50, target.HP);
        }
        [TestCase("Jake Paul", 50, 100)]
        public void AttackMethodWhereAttackersAttIsLessThanTargetHPShouldDecreaseTargetHPCorrectlyToZero(string name, int dmg, int hp)
        {
            warrior = new Warrior("Bob", 100, 100);
            Warrior target = new Warrior(name, dmg, hp);
            warrior.Attack(target);
            Assert.AreEqual(0, target.HP);
        }
    }
}