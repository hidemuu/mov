using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using System;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private readonly IDesignerParameter parameter;

        private readonly LayoutBuilder builder;

        #endregion フィールド

        #region コンストラクター

        public DesignerEngine(IDesignerParameter parameter)
        {
            this.parameter = parameter;
        }

        #endregion コンストラクター

    }
}
