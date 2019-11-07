using Geometry.Handlers;
using Geometry.Model;
using NUnit.Framework;
using System;

namespace Geometry.Tests.Handler
{
    [TestFixture]
    public class AreaCalculatorTests
    {
        AreaCalculator areaCalculator;

        [TestCase(10.0, 100.0*Math.PI)]
        [TestCase(4.0, 16.0*Math.PI)]
        [TestCase(1.0, Math.PI)]
        public void ShouldCalculateAreaOfCircle(double radius, double expectedArea)
        {
            areaCalculator = new AreaCalculator();

            var shape = new Circle(radius);

            shape.Accept(areaCalculator);

            Assert.AreEqual(expectedArea, areaCalculator.ResultedArea);

        }

        [TestCase(10,12,14, 58.787753826796276d)]
        [TestCase(9.9,12.5,17.2, 60.995570330967425d)]
        [TestCase(3,4,5,6)]
        public void ShouldCalculateAreaOfTriangle(double side1, double side2, double side3, double expectedArea)
        {
            areaCalculator = new AreaCalculator();

            var shape = new Triangle(side1,side2,side3);

            shape.Accept(areaCalculator);

            Assert.AreEqual(expectedArea, areaCalculator.ResultedArea.Value);

        }
    }
}
