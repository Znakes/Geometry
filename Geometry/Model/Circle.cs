using System;

namespace Geometry.Model
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be a positive number");
            Radius = radius;
        }

        public double GetArea() => Math.PI * Radius * Radius;
    }
}
