using System;
using System.Collections.Generic;

namespace Mov.Core.Models.Entities.Structures
{
    public sealed class BuildingContext : IDisposable
    {
        public int WallHeight = 0;
        public int WallThickness = 300; // etc.
        private static Stack<BuildingContext> stack
          = new Stack<BuildingContext>();

        static BuildingContext()
        {
            // ensure there's at least one state
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            // not strictly necessary
            if (stack.Count > 1)
                stack.Pop();
        }
    }
}
