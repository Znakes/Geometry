using Geometry.Model;

namespace Geometry.Handlers
{
    public interface IShapeVisitor
    {
        void Visit(Circle shape);
        void Visit(Triangle shape);
    }
}
