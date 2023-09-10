using Mov.Core.Layouts;
using Mov.Designer.Models;

namespace Mov.Designer.Engine
{
    public interface IDesignerFacade
    {
        #region プロパティ

        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }

        ILayoutFacade LayoutFacade { get; }

        #endregion プロパティ

        #region メソッド

        void Read();

        void Write();

        #endregion メソッド
    }
}