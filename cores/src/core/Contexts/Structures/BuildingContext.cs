using System;
using System.Collections.Generic;

namespace Mov.Core.Contexts.Structures
{
    public sealed class BuildingContext : IDisposable
    {
        #region field

        private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

        #endregion field

        #region property

        public int WallHeight { get; } = 0;
        public int WallThickness { get; } = 300;

        #endregion property

        #region constructor

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

        #endregion constructor

        #region method

        public void Dispose()
        {
            // not strictly necessary
            if (stack.Count > 1)
                stack.Pop();
        }

        #endregion method
    }
}
