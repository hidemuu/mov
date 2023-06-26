using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes
{
    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D>
        where D : IDimension, new()
    {
        public VectorOfInt()
        {
        }

        public VectorOfInt(params int[] values) : base(values)
        {
        }

        public static VectorOfInt<D> operator +
          (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }
}
