using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.Sandbox;
using Moq;

namespace Votr.Tests.Sandbox
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void CarEnsureICanCreateInstance()
        {
            Car c = new Car();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CarEnsureICanHonk()
        {
            Car c = new Car();
            Assert.AreEqual("Honk", c.Horn());
        }

        [TestMethod]
        public void CarEnsureICanBeep()
        {
            Mock<Car> mock_car = new Mock<Car>();
            mock_car.Setup(car => car.Horn()).Returns("Beep");

            //Car c = new Car();
            Car c = mock_car.Object;
            Assert.AreEqual("Beep", c.Horn());

        }

        [TestMethod]
        public void CarEnsureHonkWasCalled()
        {
            // Arrange
            Mock<Car> mock_car = new Mock<Car>();
            Car c = mock_car.Object;
            mock_car.Setup(car => car.Horn()).Returns("Beep");

            // Act
            c.MakeNoise(); // This calls the wrong "Horn". Not the mocked method.

            // Assert
            mock_car.Verify(car => car.Horn(), Times.Once); // This never runs.

        }
    }
}
