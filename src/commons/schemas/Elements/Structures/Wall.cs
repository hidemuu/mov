using Mov.Schemas.DesignPatterns.Creationals.Singletons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Schemas.Elements.Structures
{
    public class Wall
    {
        public Point Start, End;
        public int Height;

        public const int UseAmbient = int.MinValue;

        // public Wall(Point start, Point end, int elevation = UseAmbient)
        // {
        //   Start = start;
        //   End = end;
        //   Elevation = elevation;
        // }

        public Wall(Point start, Point end)
        {
            Start = start;
            End = end;
            //Elevation = BuildingContext.Elevation;
            Height = BuildingContext.Current.WallHeight;
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}, " +
                   $"{nameof(Height)}: {Height}";
        }
    }
}
