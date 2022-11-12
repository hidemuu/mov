using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class DesignerService : IDesignerService
    {
        #region フィールド

        private readonly IDesignerEngine engine;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerService(IDesignerEngine engine)
        {
            this.engine = engine;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<LayoutNodeBase> GetNodes()
        {
            return this.engine.Nodes;
        }

        public LayoutNodeBase GetNode(LocationType type)
        {
            switch (type)
            {
                case LocationType.Center:
                    return this.engine.CenterNode;
                case LocationType.Top:
                    return this.engine.TopNode;
                case LocationType.Bottom:
                    return this.engine.BottomNode;
                case LocationType.Left:
                    return this.engine.LeftNode;
                case LocationType.Right:
                    return this.engine.RightNode;
            }
            return this.engine.CenterNode;
        }

        public Shell GetShell(LocationType type)
        {
            return this.engine.GetShell(type);
        }

        #endregion メソッド
    }
}
