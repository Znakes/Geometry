using Geometry.Handlers;

namespace Geometry.Model
{
    public interface IShape
    {
        void Accept(IShapeVisitor visitor);
    }
}
