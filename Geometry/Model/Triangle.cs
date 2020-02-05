﻿using System;

namespace Geometry.Model
{
    public class Triangle : IShape, ITriangle
    {
        private readonly Lazy<bool> isRightTriangle;

        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        public bool IsRightTriangle => isRightTriangle.Value;

        public Triangle(double side1, double side2, double side3)
        {
            Validate(side1, side2, side3);

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            isRightTriangle = new Lazy<bool>(CheckIfRightTriangle);
        }

        public double GetArea()
        {
            var p = (Side1 + Side2 + Side3) / 2.0;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        protected virtual void Validate(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentException("Side of triangle must be a positive number");

            if (side1 + side2 <= side3 ||
                side1 + side3 <= side2 ||
                side2 + side3 <= side1)
                throw new Exception("Not a triangle");
        }

        private bool CheckIfRightTriangle()
        {
            var orderedSides = new double[] { Side1, Side2, Side3 };
            Array.Sort(orderedSides);

            return Side3*Side3 == (Side1*Side1 + Side2*Side2);
        }
    }
}
