using Geometry.Model;
using System;

namespace Geometry.Handlers
{
    public class AreaCalculator : IShapeVisitor
    {
        public double? ResultedArea{ get; private set; }

        public void Visit(Circle shape)
        {
            ResultedArea = Math.PI * shape.Radius * shape.Radius;
        }

        public void Visit(Triangle shape)
        {
            var p = (shape.Side1 + shape.Side2 + shape.Side3) / 2.0;
            ResultedArea = Math.Sqrt(p * (p - shape.Side1) * (p - shape.Side2) * (p - shape.Side3));
        }
    }
}
