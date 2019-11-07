using Geometry.Model;
using NUnit.Framework;
using System;

namespace Geometry.Tests.Models
{
    [TestFixture]
    public class TriangleTests
    {
        Triangle triangle;


        [TestCase(-1.0, 2.0 ,3.0)]
        [TestCase(0.0, 2.0 ,3.0)]
        [TestCase(2.0, -1.0 ,3.0)]
        [TestCase(2.0, 0.0 ,3.0)]
        [TestCase(2.0, 3.0 ,-1.0)]
        [TestCase(2.0, 3.0 ,0.0)]
        public void ShouldThrowArgumentExceptionIfSideIsNonPositive(double side1,  double side2, double side3)
        {
            Assert.Throws<ArgumentException>(()=>triangle = new Triangle(side1, side2, side3));
        }

        [Test]
        public void ShouldThrowNotATriangleExceptionIfSidesAreWrong()
        {
            double side1 = 3.0;
            double side2 = 4.0;
            double side3 = 8.0;
            Assert.Throws<Exception>(() => triangle = new Triangle(side1, side2, side3),"Not a triangle");
        }

        [Test]
        public void ShouldCreateTriangleIfAllIsCorrect()
        {
            double side1 = 3.0;
            double side2 = 4.0;
            double side3 = 6.0;
            triangle = new Triangle(side1, side2, side3);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(side1, triangle.Side1);
                Assert.AreEqual(side2, triangle.Side2);
                Assert.AreEqual(side3, triangle.Side3);
            });
        }

        [Test]
        public void ShouldIndicateIfTriangleIsRightTriangle()
        {
            double side1 = 3.0;
            double side2 = 4.0;
            double side3 = 5.0;
            triangle = new Triangle(side1, side2, side3);

            Assert.IsTrue(triangle.IsRightTriangle);
        }
    }
}
