using Mov.Graphicers.Models.Shapes;
using Mov.Graphicers.Services.Shapes.Policies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Services.Shapes
{

    public abstract class ShapeDecorator : IShape
    {
        protected internal readonly List<Type> types = new List<Type>();
        protected internal IShape shape;

        public ShapeDecorator(IShape shape)
        {
            this.shape = shape;
            if (shape is ShapeDecorator sd)
                types.AddRange(sd.types);
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Resize(float factor)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ShapeDecorator<TSelf, TCyclePolicy> : ShapeDecorator
    where TCyclePolicy : ShapeDecoratorCyclePolicy, new()
    {
        protected readonly TCyclePolicy policy = new TCyclePolicy();

        public ShapeDecorator(IShape shape) : base(shape)
        {
            if (policy.TypeAdditionAllowed(typeof(TSelf), types))
                types.Add(typeof(TSelf));
        }
    }
}
