using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes
{
    public abstract class ShapeBase : IShape
    {
        protected IRenderer renderer;

        // a bridge between the shape that's being drawn an
        // the component which actually draws it
        public ShapeBase(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }
}
