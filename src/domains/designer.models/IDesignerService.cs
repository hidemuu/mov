using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerService
    {

        #region メソッド
        IEnumerable<LayoutNodeBase> GetNodes();

        LayoutNodeBase GetNode(LocationType type);

        Shell GetShell(LocationType type);

        #endregion メソッド

    }
}
