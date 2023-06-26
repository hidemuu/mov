using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
