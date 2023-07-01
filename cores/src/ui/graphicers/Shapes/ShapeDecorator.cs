using Mov.Core.Graphicers.Shapes.Policies;
using Mov.Core.Models.Entities.Shapes;
using System;
using System.Collections.Generic;

namespace Mov.Core.Graphicers.Shapes
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
