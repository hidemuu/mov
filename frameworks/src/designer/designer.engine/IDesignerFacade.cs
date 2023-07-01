using Mov.Core.Layouts;

namespace Mov.Designer.Models
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