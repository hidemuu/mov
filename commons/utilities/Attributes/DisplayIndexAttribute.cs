using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Utilities.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DisplayIndexAttribute : Attribute
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="index"></param>
        public DisplayIndexAttribute(int index)
        {
            Index = index;
        }

        /// <summary>
        /// 表示順
        /// </summary>
        public int Index { get; } = -1;
    }
}
