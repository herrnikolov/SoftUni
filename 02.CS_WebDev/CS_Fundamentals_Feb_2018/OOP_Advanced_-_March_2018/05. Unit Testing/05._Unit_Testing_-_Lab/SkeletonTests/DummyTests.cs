namespace Skeleton.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    class DummyTests
    {
        private const int axeAttack = 10;

        private const int axeDurability = 10;

        private const int dummyExperience = 10;

        private const int dummyHealth = 10;

        private Axe axe;

        private Dummy dummy;

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            Assert.AreEqual($"Dummy is dead.", ex.Message);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.AreEqual(0, this.dummy.Health, "Dummy doesn't lose health after attack");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.AreEqual(this.dummy.GiveExperience(), dummyExperience, "Dead dummy doesn't give experience");
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            // Act
            this.dummy = new Dummy(11, dummyExperience);
            this.axe.Attack(this.dummy);

            // AssertC
            Assert.Catch<InvalidOperationException>(() => this.dummy.GiveExperience(), "Alive dummy gives experience");
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