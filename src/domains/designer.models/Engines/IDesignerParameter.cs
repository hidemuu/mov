using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Parameters
{
    public interface IDesignerParameter
    {
        #region プロパティ
        
        IDesignerRepository Repository { get; }
        
        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }

        #endregion プロパティ

        #region メソッド

        void UpdateRepository(string name);

        #endregion メソッド
    }
}
