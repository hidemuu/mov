using Mov.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Services
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
