namespace Skeleton.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        private const int axeAttack = 1;

        private const int axeDurability = 1;

        private const int dummyExperience = 20;

        private const int dummyHealth = 20;

        private Axe axe;

        private Dummy dummy;

        [Test]
        public void AttackWithBrokenAxe()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [SetUp]
        public void TestInit()
        {
            // Arrange
            this.axe = new Axe(axeAttack, axeDurability);
            this.dummy = new Dummy(dummyHealth, dummyExperience);
        }
    }
}