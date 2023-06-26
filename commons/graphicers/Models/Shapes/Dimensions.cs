using Mov.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Mov.Graphicers.Models.Shapes
{
    public static class Dimensions
    {
        public class Two : IDimension
        {
            public int Value => 2;
        }

        public class Three : IDimension
        {
            public int Value => 3;
        }
    }
}
