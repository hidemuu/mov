using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance
{
    public class PersistanceObject
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// インデックス番号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// コード
        /// </summary>
        public string Code { get; set; }
    }
}
