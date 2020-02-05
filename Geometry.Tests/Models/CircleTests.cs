using Geometry.Model;
using NUnit.Framework;
using System;

namespace Geometry.Tests.Models
{
    [TestFixture]
    public class CircleTests
    {
        Circle circle;

        [Test]
        public void ShoudlThrowArgumentExceptionIfRadiusIsNotPositive([Values(-2,0)] double radius)
        {
            Assert.Throws<ArgumentException>(() => circle = new Circle(radius), "Radius must be a positive number");
        }

        [Test]
        public void ShoudlCreateSuccessfullyIfRadiusIsPostitive()
        {
            // Arrange
            double radius = 5;

            // Act
            circle = new Circle(radius);

            // Assert
            Assert.AreEqual(radius, circle.Radius);
        }

        [TestCase(10.0, 100.0 * Math.PI)]
        [TestCase(4.0, 16.0 * Math.PI)]
        [TestCase(1.0, Math.PI)]
        public void ShouldCalculateAreaOfCircle(double radius, double expectedArea)
        {
            var shape = new Circle(radius);

            Assert.AreEqual(expectedArea, shape.GetArea());
        }
    }
}
