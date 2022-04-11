using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts
{
    public abstract class LayoutBase
    {
        #region プロパティ

        public int Index { get; set; }

        public string LayoutType { get; set; }

        public string LayoutStyle { get; set; }

        public double Indent { get; set; }

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBase()
        {

        }


    }
}
