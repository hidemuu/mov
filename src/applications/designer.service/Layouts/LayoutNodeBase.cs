using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts
{
    public abstract class LayoutNodeBase : LayoutBase, IEnumerable<LayoutBase>
    {
        #region プロパティ

        public bool IsExpand { get; set; }

        #endregion

        public IEnumerator<LayoutBase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
