using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private readonly IDesignerParameter parameter;

        private readonly LayoutBuilder builder;

        #endregion フィールド

        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        public DesignerEngine(IDesignerParameter parameter)
        {
            this.parameter = parameter;
            this.builder = new LayoutBuilder(parameter.Query);
            this.builder.Build();
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<LayoutNodeBase> GetNodes()
        {
            return this.builder.Nodes;
        }

        public LayoutNodeBase GetCenterNode()
        {
            return this.builder.CenterNode;
        }

        public LayoutNodeBase GetTopNode()
        {
            return this.builder.TopNode;
        }

        public LayoutNodeBase GetBottomNode()
        {
            return this.builder.BottomNode;
        }

        public LayoutNodeBase GetLeftNode()
        {
            return this.builder.LeftNode;
        }

        public LayoutNodeBase GetRightNode()
        {
            return this.builder.RightNode;
        }

        public Shell GetCenterShell()
        {
            return this.parameter.Query.Shell.Get(LocationType.Center.ToString());
        }

        public Shell GetTopShell()
        {
            return this.parameter.Query.Shell.Get(LocationType.Top.ToString());
        }

        public Shell GetBottomShell()
        {
            return this.parameter.Query.Shell.Get(LocationType.Bottom.ToString());
        }

        public Shell GetLeftShell()
        {
            return this.parameter.Query.Shell.Get(LocationType.Left.ToString());
        }

        public Shell GetRightShell()
        {
            return this.parameter.Query.Shell.Get(LocationType.Right.ToString());
        }

        #endregion メソッド

    }
}
