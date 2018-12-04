using System;
using NUnit.Framework;

namespace SkeletonTests
{
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            //Arrange
            Axe axe = new Axe(1, 0);
            Dummy dummy = new Dummy(10, 10);

            //Act
            //axe.Attack(dummy);

            //Assert
            Assert.That(()=> axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
