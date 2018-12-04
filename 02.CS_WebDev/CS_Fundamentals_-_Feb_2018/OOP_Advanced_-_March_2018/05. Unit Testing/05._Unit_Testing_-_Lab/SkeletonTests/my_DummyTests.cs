using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SkeletonTests
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 20);
            
            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(5));
            Assert.AreEqual(5, dummy.Health);
        }
    }
}
