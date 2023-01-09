using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Mov.Schemas.Elements.Units.Coordinates.Shapes._2D.Vectors
{
    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }
}
