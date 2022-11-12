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

        public LayoutNodeBase GetCenterNode()
        {
            return this.engine.CenterNode;
        }

        public LayoutNodeBase GetTopNode()
        {
            return this.engine.TopNode;
        }

        public LayoutNodeBase GetBottomNode()
        {
            return this.engine.BottomNode;
        }

        public LayoutNodeBase GetLeftNode()
        {
            return this.engine.LeftNode;
        }

        public LayoutNodeBase GetRightNode()
        {
            return this.engine.RightNode;
        }

        public Shell GetCenterShell()
        {
            return this.engine.GetCenterShell();
        }

        public Shell GetTopShell()
        {
            return this.engine.GetTopShell();
        }

        public Shell GetBottomShell()
        {
            return this.engine.GetBottomShell();
        }

        public Shell GetLeftShell()
        {
            return this.engine.GetLeftShell();
        }

        public Shell GetRightShell()
        {
            return this.engine.GetRightShell();
        }

        #endregion メソッド
    }
}
